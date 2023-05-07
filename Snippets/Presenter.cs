public class CreateEntityPresenter : ICreateEntityPresenter
{
    private readonly IMapper<Entity, EntityViewModel> mapper;

    public CreateEntityPresenter(IMapper<Entity, EntityViewModel> mapper)
    {
        this.mapper = mapper;
    }

    public Response Response { get; set; }

    public IResult GetResult(HttpRequest request = null)
    {
        return Response.IsValid ?
            Results.Created($"//{mapper.Map(Response.GetParameter<Entity>()).Id}", mapper.Map(Response.GetParameter<Entity>())) :
            Response.ToWebApiResult(request);
    }
}