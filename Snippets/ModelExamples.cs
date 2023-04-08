/// <summary>
/// The actual data entity of the component.
/// </summary>
public class Component
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual List<Package> Packages { get; set; }
    public virtual Expander Expander { get; set; }
}

/// <summary>
/// The Component entity represented as a ViewModel.
/// </summary>
public class ComponentViewModel : ViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PackageViewModel> Packages { get; set; }
    public ExpanderViewModel Expander { get; set; }

    #region ns-custom-properties
    #endregion ns-custom-properties
}

/// <summary>
/// The RequestModel for the Delete command for a Component entity.
/// </summary>
public class DeleteComponentCommand : RequestModel
{
    public Guid Id { get; set; }
}