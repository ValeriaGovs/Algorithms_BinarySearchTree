using System;

namespace Algorithms_BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {

            timeTest t = new timeTest();

            bool Ordered = false;
            
            var TreeNode = new tree();

            t.Test(TreeNode.Insert, "Insert", Ordered,10000);

            // проверка, что все добавили правильно
            //TreeNode.Traverse(TreeNode.root);

            t.Test(TreeNode.Search, "Search", Ordered, 1000);
            t.Test(TreeNode.Remove, "Remove", Ordered, 1000);

            // проверка, что все удалили правильно
            //TreeNode.Traverse(TreeNode.root); 
            


            var TreeNodeOrdered = new tree();
            Ordered = true;
            t.Test(TreeNodeOrdered.Insert, "InsertSorted ", Ordered, 10000);

            // проверка, что все добавили правильно
            //TreeNodeOrdered.Traverse(TreeNodeOrdered.root);

            t.Test(TreeNodeOrdered.Search, "SearchSorted", false, 1000);
            t.Test(TreeNodeOrdered.Remove, "RemoveSorted", false, 1000);

            // проверка, что все удалили правильно
            //TreeNodeOrdered.Traverse(TreeNodeOrdered.root);

        }
    }
}
