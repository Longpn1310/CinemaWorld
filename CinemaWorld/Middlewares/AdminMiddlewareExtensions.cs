namespace CinemaWorld.Middlewares
{
    public static class AdminMiddlewareExtensions
    {
        public static IApplicationBuilder UseAdminMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminMiddleware>();
        }
    }
}
