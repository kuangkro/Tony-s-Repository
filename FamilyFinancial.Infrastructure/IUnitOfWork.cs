namespace FamilyFinancial.Infrastructure
{
    public interface IUnitOfWork
    {
        bool Commit();

        bool Commited { get; }

        void RollBack();
    }
}
