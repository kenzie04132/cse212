using NUnit.Framework;
using prove_09;

namespace test_prove_09;

public class Tests
{
    private BinarySearchTree BuildBasicTree()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);
        return tree;
    }
    
    [Test]
    public void TestProblem1_InsertDuplicate()
    {
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        BinarySearchTree tree = BuildBasicTree();
        // After implementing 'no duplicates' rule,
        // this next insert will have no effect on the tree.
        // TODO Problem 1
        tree.Insert(7);
        Assert.That(tree.ToString(), Is.EqualTo("<Bst>{1, 3, 4, 5, 6, 7, 10}"));
    }

    [Test]
    public void TestProblem2_Contains3()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Contains(3), Is.True);
    }

    [Test]
    public void TestProblem2_Contains2()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Contains(2), Is.False);
    }

    [Test]
    public void TestProblem2_Contains7()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Contains(7), Is.True);
    }

    [Test]
    public void TestProblem2_Contains6()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Contains(6), Is.True);
    }

    [Test]
    public void TestProblem2_Contains9()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Contains(9), Is.False);
    }

    [Test]
    public void TestProblem3_Reverse()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.Reverse(), Is.EquivalentTo(new[]{10, 7, 6, 5, 4, 3, 1}));
    }

    [Test]
    public void TestProblem4_Heights()
    {
        BinarySearchTree tree = BuildBasicTree();
        Assert.That(tree.GetHeight(), Is.EqualTo(3));
        tree.Insert(8);
        Assert.That(tree.GetHeight(), Is.EqualTo(4));
    }

    [Test]
    public void TestProblem5_Simple()
    {
        var tree = BinarySearchTree.CreateTreeFromSortedList([10, 20, 30, 40, 50, 60]);
        var treeDisplay = tree.GetTreeDisplay();
        Console.WriteLine(treeDisplay);
        var expected = "      30        \n   ┌───┴───┐    \n  10      50    \n ┌─┴─┐   ┌─┴─┐  \n    20  40  60  \n";
        Assert.That(treeDisplay, Is.EqualTo(expected), "Expected the tree to be: \n" + expected);
    }

    [Test]
    public void TestProblem5_127()
    {
        var tree = BinarySearchTree.CreateTreeFromSortedList(Enumerable.Range(0, 127).ToArray()); // 2^7 - 1 Nodes
        var treeDisplay = tree.GetTreeDisplay();
        Console.WriteLine(treeDisplay);
        var expected = "                                                                                                                              63                                                                                                                                \n                                                               ┌───────────────────────────────────────────────────────────────┴───────────────────────────────────────────────────────────────┐                                                                \n                                                              31                                                                                                                              95                                                                \n                               ┌───────────────────────────────┴───────────────────────────────┐                                                               ┌───────────────────────────────┴───────────────────────────────┐                                \n                              15                                                              47                                                              79                                                             111                                \n               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                \n               7                              23                              39                              55                              71                              87                             103                             119                \n       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐        \n       3              11              19              27              35              43              51              59              67              75              83              91              99             107             115             123        \n   ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐    \n   1       5       9      13      17      21      25      29      33      37      41      45      49      53      57      61      65      69      73      77      81      85      89      93      97     101     105     109     113     117     121     125    \n ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐  \n 0   2   4   6   8  10  12  14  16  18  20  22  24  26  28  30  32  34  36  38  40  42  44  46  48  50  52  54  56  58  60  62  64  66  68  70  72  74  76  78  80  82  84  86  88  90  92  94  96  98  100 102 104 106 108 110 112 114 116 118 120 122 124 126 \n";
        Assert.That(treeDisplay, Is.EqualTo(expected), "Expected the tree to be: \n" + expected);
    }

    [Test]
    public void TestProblem5_128()
    {
        var tree = BinarySearchTree.CreateTreeFromSortedList(Enumerable.Range(0, 128).ToArray()); // 2^8 Nodes
        var treeDisplay = tree.GetTreeDisplay();
        Console.WriteLine(treeDisplay);
        var expected = "                                                                                                                                                                                                                                                              63                                                                                                                                                                                                                                                                \n                                                                                                                               ┌───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐                                                                                                                                \n                                                                                                                              31                                                                                                                                                                                                                                                              95                                                                                                                                \n                                                               ┌───────────────────────────────────────────────────────────────┴───────────────────────────────────────────────────────────────┐                                                                                                                               ┌───────────────────────────────────────────────────────────────┴───────────────────────────────────────────────────────────────┐                                                                \n                                                              15                                                                                                                              47                                                                                                                              79                                                                                                                             111                                                                \n                               ┌───────────────────────────────┴───────────────────────────────┐                                                               ┌───────────────────────────────┴───────────────────────────────┐                                                               ┌───────────────────────────────┴───────────────────────────────┐                                                               ┌───────────────────────────────┴───────────────────────────────┐                                \n                               7                                                              23                                                              39                                                              55                                                              71                                                              87                                                             103                                                             119                                \n               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                               ┌───────────────┴───────────────┐                \n               3                              11                              19                              27                              35                              43                              51                              59                              67                              75                              83                              91                              99                             107                             115                             123                \n       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐        \n       1               5               9              13              17              21              25              29              33              37              41              45              49              53              57              61              65              69              73              77              81              85              89              93              97             101             105             109             113             117             121             125        \n   ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐       ┌───┴───┐    \n   0       2       4       6       8      10      12      14      16      18      20      22      24      26      28      30      32      34      36      38      40      42      44      46      48      50      52      54      56      58      60      62      64      66      68      70      72      74      76      78      80      82      84      86      88      90      92      94      96      98     100     102     104     106     108     110     112     114     116     118     120     122     124     126    \n ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐   ┌─┴─┐  \n                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            127 \n";
        Assert.That(treeDisplay, Is.EqualTo(expected), "Expected the tree to be: \n" + expected);
    }

    [Test]
    public void TestProblem5_1()
    {
        var tree = BinarySearchTree.CreateTreeFromSortedList([42]);
        var treeDisplay = tree.GetTreeDisplay();
        Console.WriteLine(treeDisplay);
        var expected = "42  \n";
        Assert.That(treeDisplay, Is.EqualTo(expected), "Expected the tree to be: \n" + expected);
    }

    [Test]
    public void TestProblem5_Empty()
    {
        var tree = BinarySearchTree.CreateTreeFromSortedList([]);
        var treeDisplay = tree.GetTreeDisplay();
        Console.WriteLine(treeDisplay);
        var expected = "    \n";
        Assert.That(treeDisplay, Is.EqualTo(expected), "Expected the tree to be: \n" + expected);
    }
}