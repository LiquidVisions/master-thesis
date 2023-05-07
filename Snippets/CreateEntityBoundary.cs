internal class CreateEntityBoundary : IBoundary<CreateEntityRequestModel>
{
    private readonly IInteractor<CreateEntityRequestModel> interactor;

    public CreateEntityBoundary(IInteractor<CreateEntityRequestModel> interactor)
    {
        this.interactor = interactor;
    }

    public async Task Execute(CreateEntityRequestModel requestModel, IPresenter presenter) =>
        presenter.Response = await interactor.ExecuteUseCase(requestModel);
}