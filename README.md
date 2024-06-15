# Evaluating a NAND Tree

A NAND Tree is a full binary tree composed of leaves which are values containing 0 or 1. The parents of this tree are NAND operators which evaluate the values of their children.

In our representations, we use -1 as the representation of a NAND gate.

        -1
        / \
       /   \
      -1   -1          For instance this NAND Tree once evaluated will contain the value of 1 in its root
     / \   / \
    /   \ /   \
    1   0 1   1

If we let n be the number of leaves in the NAND Tree, a naive implementation of an algorithm evaluating the above tree will take O(n) time.

However if we take the Left-First solution and only check the left node of the tree. If the left node of the tree is false, we can skip evaluating its sibling and update the parent with the correct value, because (0 NAND 0 = 1 & 0 NAND 1 = 1)

However this solution is incomplete as there is a possiblity of the evaluation process to still take O(n) time regardless.

That is when all children of the left subtree evaluate to the value of 1. Here we propose an algorithm that creates a NAND Tree in which the left-first algorithm fails to optimize the Evaluation.

Given a desired number of leaves, and the head node containing the required end value of the NAND tree (either 0 or 1), we can create a NAND tree in which the left subtree will always evaluate to 1, therefore making the left-first algorithm virtually identical to the naive solution in terms of running time.
The algorithm is done recursively like this:

* If the value of log2(leafcount) is equal to the height desired, return the current node
* If the value of the currently given node is 1, create a left node with the value of 1 and a right node with the value of 0, else if the value is 0 create both left and right nodes with the value of 1
* Then reset the value of the current node to -1 and first recursively do the same for the left and then the right subtree
* At the end return the current node

The function of the algorithm described is implemented in Lib/NANDTreeCreator utility class under CreateNANDTreeUtil function.
