namespace VaultForce.Canvas.WebGL
{
    public class WebGL2Context : WebGLContext
    {
        #region Constants
        private const string CONTEXT_NAME = "WebGL2";
        private const string BIND_BUFFER_BASE = "bindBufferBase";
        private const string BIND_VERTEX_ARRAY = "bindVertexArray";
        private const string BLIT_FRAMEBUFFER = "blitFramebuffer";
        private const string CREATE_VERTEX_ARRAY = "createVertexArray";
        private const string DELETE_VERTEX_ARRAY = "deleteVertexArray";
        private const string DRAW_ARRAYS_INSTANCED = "drawArraysInstanced";
        private const string DRAW_ELEMENTS_INSTANCED = "drawElementsInstanced";
        private const string GET_UNIFORM_BLOCK_INDEX = "getUniformBlockIndex";
        private const string TEX_STORAGE_2D = "texStorage2D";
        private const string UNIFORM_BLOCK_BINDING = "uniformBlockBinding";
        private const string VERTEX_ATTRIB_DIVISOR = "vertexAttribDivisor";
        private const string VERTEX_ATTRIB_IPOINTER = "vertexAttribIPointer";
        #endregion

        public WebGL2Context(BeCanvas reference, WebGLContextAttributes? attributes = null) : base(reference, attributes, CONTEXT_NAME)
        {
        }

        #region Methods
        public async Task BindBufferBaseAsync(BufferType target, uint index, WebGLBuffer buffer) => await this.BatchCallAsync(BIND_BUFFER_BASE, isMethodCall: true, target, index, buffer);
        public async Task BindVertexArrayAsync(WebGLVertexArrayObject vertexArray) => await this.BatchCallAsync(BIND_VERTEX_ARRAY, isMethodCall: true, vertexArray);
        public async Task BlitFramebufferAsync(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, BufferBits mask, BlitFilter filter) => await this.BatchCallAsync(BLIT_FRAMEBUFFER, isMethodCall: true, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        public async Task<WebGLVertexArrayObject> CreateVertexArrayAsync() => await this.CallMethodAsync<WebGLVertexArrayObject>(CREATE_VERTEX_ARRAY);
        public async Task DeleteVertexArrayAsync(WebGLVertexArrayObject vertexArray) => await this.BatchCallAsync(DELETE_VERTEX_ARRAY, isMethodCall: true, vertexArray);
        public async Task DrawArraysInstancedAsync(Primitive mode, int first, int count, int instanceCount) => await this.BatchCallAsync(DRAW_ARRAYS_INSTANCED, isMethodCall: true, mode, first, count, instanceCount);
        public async Task DrawElementsInstancedAsync(Primitive mode, int count, DataType type, long offset, int instanceCount) => await this.BatchCallAsync(DRAW_ELEMENTS_INSTANCED, isMethodCall: true, mode, count, type, offset, instanceCount);
        public async Task<uint> GetUniformBlockIndexAsync(WebGLProgram program, string uniformBlockName) => await this.CallMethodAsync<uint>(GET_UNIFORM_BLOCK_INDEX, program, uniformBlockName);
        public async Task TexStorage2DAsync(Texture2DType target, int levels, PixelFormat internalformat, int width, int height) => await this.BatchCallAsync(TEX_STORAGE_2D, isMethodCall: true, target, levels, internalformat, width, height);
        public async Task UniformBlockBindingAsync(WebGLProgram program, uint uniformBlockIndex, uint uniformBlockBinding) => await this.BatchCallAsync(UNIFORM_BLOCK_BINDING, isMethodCall: true, program, uniformBlockIndex, uniformBlockBinding);
        public async Task VertexAttribDivisorAsync(uint index, uint divisor) => await this.BatchCallAsync(VERTEX_ATTRIB_DIVISOR, isMethodCall: true, index, divisor);
        public async Task VertexAttribIPointerAsync(uint index, int size, DataType type, int stride, long offset) => await this.BatchCallAsync(VERTEX_ATTRIB_IPOINTER, isMethodCall: true, index, size, type, stride, offset);
        #endregion
    }
}
