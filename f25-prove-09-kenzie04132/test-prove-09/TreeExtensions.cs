using System.Reflection;
using System.Text;
using prove_09;

namespace test_prove_09;

public static class TreeExtensions
{
    
    private static List<int?> ToList(this BinarySearchTree tree)
    {
        var root = (Node?)typeof(BinarySearchTree).GetField("_root", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(tree);
        List<Node?> treeData = [root];

        int Deepest(Node? node)
        {
            return node == null ? 0 : 1 + Math.Max(Deepest(node.Left), Deepest(node.Right));
        }

        var lastIndex = (1 << (Math.Max(Deepest(root), 1) - 1)) - 1;
        for (var i = 0; i < lastIndex; ++i)
        {
            var node = treeData[i];
            if (node != null)
            {
                treeData.Add(node.Left);
                treeData.Add(node.Right);
            }
            else
            {
                treeData.Add(null);
                treeData.Add(null);
            }

            
        }

        return treeData.Select(n => n?.Data).ToList();
    }

    public static string GetTreeDisplay(this BinarySearchTree tree)
    {
        var data = tree.ToList();
        
        string[] rotation = ["┌", "┴", "┐", ""];
        char[] rotationFiller = [' ', '─', '─', ' '];
        string extra = "┘";

        var levels = Log2(data.Count + 1);
        var fullTree = new StringBuilder();
        for (int level = 0; level < levels; level++)
        {
            var rotationIndex = 0;
            var firstIndex = (1 << level) - 1;
            var lastIndex = Math.Min((1 << (level + 1)) - 2, data.Count - 1) + 1;
            var padding = 1 << (levels - level);
            string format = $"{{0,{padding}}}";

            var treeLines = new StringBuilder();
            var builder = new StringBuilder();
            for (var i = firstIndex; i < lastIndex; i++)
            {
                var value = data[i];
                var output = string.Format(format, value);
                builder.Append(output.PadRight(padding * 2));

                treeLines.Append(rotation[rotationIndex].PadLeft(padding, rotationFiller[rotationIndex]));
                rotationIndex++;
                rotationIndex %= 4;
                if (i == data.Count - 1 && (i & 1) == 1)
                    rotation[rotationIndex] = extra;
                treeLines.Append(rotation[rotationIndex].PadLeft(padding, rotationFiller[rotationIndex]));
                rotationIndex++;
                rotationIndex %= 4;
            }

            if (level > 0)
                fullTree.Append(treeLines).Append('\n');
            fullTree.Append(builder).Append('\n');
        }

        return fullTree.ToString();
    }
    
    private static int Log2(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Positive integers only", nameof(n));

        var result = 0;
        while (n > 1)
        {
            n >>= 1;
            ++result;
        }

        return result;
    }
}