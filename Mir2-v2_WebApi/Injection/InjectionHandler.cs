using Mir2_v2_WebApi.InjectionHandlers;

namespace Mir2_v2_WebApi.Helpers.InjectionHandlers {
    public static class InjectionHandler {
        public static AccountDbInjectionHandler AccountDbInjectionHandler { get; } = new AccountDbInjectionHandler();
    }
}
