namespace Domain.Interfaces;

public interface ICopiable<Model>
{
    void Copy(Model model);
}