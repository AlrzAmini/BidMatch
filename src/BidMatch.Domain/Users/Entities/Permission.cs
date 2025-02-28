namespace BidMatch.Domain.Users.Entities;

public sealed class Permission
{
    public Guid Id { get; private set; }
    
    public string Code { get; private set; }

    public ICollection<RolePermission> RolePermissions { get; private set; } = new List<RolePermission>();

    private Permission() { }

    public Permission(string code)
    {
        Id = Guid.CreateVersion7();
        Code = code.ToLower(); 
    }
}