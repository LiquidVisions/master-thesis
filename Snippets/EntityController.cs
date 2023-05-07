public static class EntityController
{
    // ...

    private static WebApplication MapCreateEntity(this WebApplication app)
    {
        RouteHandlerBuilder builder =  app.MapPost(endpointTemplate, async (CreateEntityRequestModel model, IBoundary<CreateEntityRequestModel> boundary, ICreateEntityPresenter presenter, HttpRequest request) =>
        {
            await boundary.Execute(model, presenter);
            return presenter.GetResult(request);
        });

        builder.Produces(StatusCodes.Status201Created, typeof(EntityViewModel));
        builder.Produces(StatusCodes.Status500InternalServerError, typeof(ErrorViewModel));
        builder.Produces(StatusCodes.Status400BadRequest, typeof(ErrorViewModel));
        builder.WithTags("Entities");

        return app;
    }

    // ...
}