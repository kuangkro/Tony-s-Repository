namespace FamilyFinancial.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
