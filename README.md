# Evaluating a NAND Tree

A NAND Tree is a full binary tree composed of leaves which are values containing 0 or 1. The parents of this tree are NAND operators which evaluate the values of their children.

In our representations, we use the nullable capability of the Boolean class in C# as the representation of a NAND gate.

        null
        / \
       /   \
     null   false          For instance this NAND Tree once evaluated will contain the value of 1 in its root
     / \
    /   \
  true  false

If we let n be the number of leaves in the NAND Tree, a naive implementation of an algorithm evaluating the above tree will take O(n) time.

However if we take the Left-First solution and only check the left node of the tree. If the left node of the tree is false, we can skip evaluating its sibling and update the parent with the correct value, because (false NAND false = true & false NAND true = true)

However this solution is incomplete as there is a possiblity of the evaluation process to still take O(n) time.

That is when all children of the left subtree contain the value of True. Here we propose an algorithm that creates a NAND Tree in which the left-first algorithm fails to optimize the Evaluation.
