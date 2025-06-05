public class TreeNode
{
    public int id;
    public string product;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int id, string product)
    {
        this.id = id;
        this.product = product;
        this.Left = null;
        this.Right = null;
    }
}

public class BinaryTree
{
    private TreeNode head;

    public BinaryTree()
    {
        head = null;
    }

    public void Add(int id, string product)
    {
        TreeNode newNode = new TreeNode(id, product);

        if (head == null)
        {
            head = newNode; 
        }
        else
        {
            TreeNode currentNode = head;
            TreeNode parentNode = null;

            while (currentNode != null)
            {
                parentNode = currentNode;

                if (newNode.id < currentNode.id)
                {
                    currentNode = currentNode.Left;
                }
                else if (newNode.id > currentNode.id)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode.product = newNode.product;
                    return;
                }
            }

            if (newNode.id < parentNode.id)
            {
                parentNode.Left = newNode;
            }
            else
            {
                parentNode.Right = newNode;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree myTree = new BinaryTree();

        myTree.Add(50, "Apple");
        myTree.Add(30, "Banana");
        myTree.Add(70, "Cherry");
        myTree.Add(20, "Date");
        myTree.Add(40, "Elderberry");
        myTree.Add(60, "Fig");
        myTree.Add(80, "Grape");
    }
}
