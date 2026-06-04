namespace Labb_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sjukhus
            TreeNode hospital = new TreeNode("1", "Sjukhur", "Falu lasarett");

            // avdelningar
            TreeNode akuten = new TreeNode("2", "Avdelning", "Akuten");
            TreeNode medicin = new TreeNode("3", "Avdelning", "Medicinavdelningen");

            hospital.FirstChild = akuten;
            akuten.NextSibling = medicin;

        }
    }
}
