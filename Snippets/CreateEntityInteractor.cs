internal class CreateEntityInteractor : IInteractor<CreateEntityRequestModel>
{
    //...

    public async Task<Response> ExecuteUseCase(CreateEntityRequestModel requestModel)
    {
        Response result = validator.Validate(requestModel);
        if (result.IsValid)
        {
            try
            {
                Entity entity = mapper.Map(requestModel);
                entity.Id = Guid.NewGuid();

                result.SetParameter(entity);

                int repositoryResult = await repository.Create(entity);
                if (repositoryResult != 1)
                {
                    result.AddError(ErrorCodes.InternalServerError, $"Failed to create {nameof(Entity)}.");
                    return result;
                }
            }
            catch (Exception exception)
            {
                result.AddError(ErrorCodes.InternalServerError, exception.Message);
            }
        }

        return result;
    }
}