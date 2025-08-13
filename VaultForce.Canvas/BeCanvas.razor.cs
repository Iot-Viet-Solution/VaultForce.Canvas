using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace VaultForce.Canvas;

public partial class BeCanvas(PersistentComponentState applicationState) : ComponentBase, IDisposable
{
    [Parameter] public long Height { get; set; }

    [Parameter] public long Width { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }
    [Parameter] public Func<MouseEventArgs, Task> OnClick { get; set; } = _ => Task.CompletedTask;
    [Parameter] public Func<MouseEventArgs, Task> OnContextMenu { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<MouseEventArgs, Task> OnMouseDown { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<MouseEventArgs, Task> OnMouseMove { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<MouseEventArgs, Task> OnMouseOut { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<MouseEventArgs, Task> OnMouseOver { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<MouseEventArgs, Task> OnMouseUp { get; set; } = _ => Task.CompletedTask;

    [Parameter] public Func<WheelEventArgs, Task> OnMouseWheel { get; set; } = _ => Task.CompletedTask;

    protected string Id { get; set; } = string.Empty;

    protected ElementReference CanvasRef = default!;

    public ElementReference CanvasReference => CanvasRef;

    [Inject] internal IJSRuntime JsRuntime { get; set; } = default!;

    private PersistingComponentStateSubscription _persistingThemeSubscription;

    private const string IdKeyPersistent = "canvas-id";

    protected override void OnInitialized()
    {
        applicationState.TryTakeFromJson<string>(IdKeyPersistent, out var instance);
        Id = string.IsNullOrEmpty(instance) ? Guid.NewGuid().ToString() : instance;
        _persistingThemeSubscription = applicationState.RegisterOnPersisting(PersistId);
    }

    private Task PersistId()
    {
        applicationState.PersistAsJson(IdKeyPersistent, Id);
        return Task.CompletedTask;
    }


    public void Dispose()
    {
        _persistingThemeSubscription.Dispose();
    }

    private Task ActionOnClick(MouseEventArgs arg)
    {
        return OnClick(arg);
    }

    private Task ActionOnMouseDown(MouseEventArgs arg)
    {
        return OnMouseDown(arg);
    }

    private Task ActionMouseOut(MouseEventArgs arg)
    {
        return OnMouseOut(arg);
    }

    private Task ActionMouseMove(MouseEventArgs arg)
    {
        return OnMouseMove(arg);
    }

    private Task ActionMouseOver(MouseEventArgs arg)
    {
        return OnMouseOver(arg);
    }

    private Task ActionContextMenu(MouseEventArgs arg)
    {
        return OnContextMenu(arg);
    }

    private Task ActionOnMouseUp(MouseEventArgs arg)
    {
        return OnMouseUp(arg);
    }

    private Task ActionMouseWheel(WheelEventArgs arg)
    {
        return OnMouseWheel(arg);
    }
}