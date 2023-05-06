internal class CreateEntityValidator : AbstractValidator<CreateEntityCommand>, IValidator<CreateEntityCommand>
{
    public CreateEntityValidator()
    {
        #region ns-custom-validations

        RuleFor(x => x.Name).NotEmpty();

        #endregion ns-custom-validations
    }

    public new Response Validate(CreateEntityCommand objectToValidate) => 
        base.Validate(objectToValidate)
            .ToResponse();
}