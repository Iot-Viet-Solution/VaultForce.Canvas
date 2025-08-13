using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VaultForce.Canvas
{
    public abstract class RenderingContext : IDisposable
    {
        private const string NamespacePrefix = "BlazorExtensions";
        private const string GetPropertyAction = "getProperty";
        private const string GetActualRenderSize = "getActualRenderSize";
        private const string CallMethodAction = "call";
        private const string CallBatchAction = "callBatch";
        private const string AddAction = "add";
        private const string RemoveAction = "remove";
        private readonly List<object[]> _batchedCallObjects = new();
        private readonly string _contextName;
        private readonly IJSRuntime _jsRuntime;
        private readonly object? _parameters;
        private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);

        private bool _awaitingBatchedCall;
        private bool _batching;
        private bool _initialized;

        public ElementReference Canvas { get; }

        internal RenderingContext(BeCanvas reference, string contextName, object? parameters = null)
        {
            Canvas = reference.CanvasReference;
            _contextName = contextName;
            _jsRuntime = reference.JsRuntime;
            _parameters = parameters;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously; Reason: extension point for subclasses, which may do asynchronous work
        protected virtual async Task ExtendedInitializeAsync() { }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        internal async Task<RenderingContext> InitializeAsync()
        {
            await _semaphoreSlim.WaitAsync();
            if (!_initialized)
            {
                await _jsRuntime.InvokeAsync<object>($"{NamespacePrefix}.{_contextName}.{AddAction}", Canvas, _parameters);
                await ExtendedInitializeAsync();
                _initialized = true;
            }
            _semaphoreSlim.Release();
            return this;
        }

        #region Protected Methods

        /// <summary>
        /// use it to reduce the number of calls to JS. use in the beginning of a batch
        /// </summary>
        public async Task BeginBatchAsync()
        {
            await _semaphoreSlim.WaitAsync();
            _batching = true;
            _semaphoreSlim.Release();
        }

        /// <summary>
        /// use it to reduce the number of calls to JS. use in the end of a batch
        /// </summary>
        public async Task EndBatchAsync()
        {
            await _semaphoreSlim.WaitAsync();

            await BatchCallInnerAsync();
        }

        protected async Task BatchCallAsync(string name, bool isMethodCall, params object[] value)
        {
            await _semaphoreSlim.WaitAsync();

            var callObject = new object[value.Length + 2];
            callObject[0] = name;
            callObject[1] = isMethodCall;
            Array.Copy(value, 0, callObject, 2, value.Length);
            _batchedCallObjects.Add(callObject);

            if (_batching || _awaitingBatchedCall)
            {
                _semaphoreSlim.Release();
            }
            else
            {
                await BatchCallInnerAsync();
            }
        }

        protected async Task<T> GetPropertyAsync<T>(string property)
        {
            return await _jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{_contextName}.{GetPropertyAction}", Canvas, property);
        }
        
        public async Task<float[]> ResizeCanvasAsync()
        {
            return await _jsRuntime.InvokeAsync<float[]>($"{NamespacePrefix}.{_contextName}.{GetActualRenderSize}", Canvas);
        }

        protected T CallMethod<T>(string method)
        {
            return CallMethodAsync<T>(method).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method)
        {
            return await _jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{_contextName}.{CallMethodAction}", Canvas, method);
        }

        protected T CallMethod<T>(string method, params object[] value)
        {
            return CallMethodAsync<T>(method, value).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method, params object[] value)
        {
            return await _jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{_contextName}.{CallMethodAction}", Canvas, method, value);
        }

        private async Task BatchCallInnerAsync()
        {
            _semaphoreSlim.Release();
            _awaitingBatchedCall = true;
            var currentBatch = _batchedCallObjects.ToArray();
            _batchedCallObjects.Clear();

            await _jsRuntime.InvokeVoidAsync($"{NamespacePrefix}.{_contextName}.{CallBatchAction}", Canvas, currentBatch);

            await _semaphoreSlim.WaitAsync();
            _awaitingBatchedCall = false;
            _batching = false;
            _semaphoreSlim.Release();
        }

        public void Dispose()
        {
            Task.Run(async () => await _jsRuntime.InvokeAsync<object>($"{NamespacePrefix}.{_contextName}.{RemoveAction}", Canvas));
        }

        #endregion
    }
}