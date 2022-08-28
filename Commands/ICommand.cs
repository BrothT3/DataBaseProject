namespace MonoGameTemplate
{
    public interface ICommand
    {
        void Execute(Player player);

        void Execute(Camera camera);
    }
}
