namespace NeuzCli.ConsoleApp
{
    public class MenuCls
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Action Action { get; set; } = () => { };

        public IEnumerable<MenuCls> SubMenus { get; set; } = new List<MenuCls>();

        public override string ToString()
        {
            return Description;
        }
    }
}