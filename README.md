# Evaluating a NAND Tree

A NAND Tree is a full binary tree composed of leaves which are values containing 0 or 1. The parents of this tree are NAND operators which evaluate the values of their children.

        -1
        / \
       /   \
      -1   -1          For instance this NAND Tree once evaluated will contain the value of 1 in its root
     / \   / \
    /   \ /   \
    1   0 1   1

In our representations, we'll use an enum containing signed 8-bit integers. -1 for Gate, 1 and 0 for a valid boolean value.

## Evaluation Algorithms

If we let n be the number of leaves in the NAND Tree, a naive implementation of an algorithm evaluating the above tree will take O(n) time.

However if we take the Left-First solution and only check the left node of the tree. If the left node of the tree is false, we can skip evaluating its sibling and update the parent with the correct value, because (0 NAND 0 = 1 & 0 NAND 1 = 1)

However this solution is incomplete as there is a possiblity of the evaluation process to still take O(n) time regardless, that is when all children of the left subtree evaluate to the value of 1.

Here we propose an algorithm that creates a NAND Tree in which the left-first algorithm fails to optimize the Evaluation.

## 1. O(n) left-first algorithm

Given a desired number of leaves, and the head node containing the required end value of the NAND tree (either 0 or 1), we can create a NAND tree in which the left subtree will always evaluate to 1, therefore making the left-first algorithm virtually identical to the naive solution in terms of running time.
The algorithm is done recursively like this:

* If the value of log2(leafcount) is equal to the height desired, return the current node
* If the value of the currently given node is 1, create a left node with the value of 1 and a right node with the value of 0, else if the value is 0 create both left and right nodes with the value of 1
* Then reset the value of the current node to -1 and first recursively do the same for the left and then the right subtree
* At the end return the current node

The function of the algorithm described is implemented in Lib/NANDTreeCreator utility class under CreateNANDTreeUtil function.

The time complexity of our algorithm is O(nlogn)

## 2. Randomized-First Algorithm

## 3. Proving T~0(n) = O(n^2)

## 4. Probability of Evaluation

Let's denote the probability that the root of the tree will evaluate to 0 or 1 as respectively P0(n) and P1(n). Solving this probability requires a recursive relation.

When the left and right subtrees evaluate to 1 is the only possibility in which the parent will be 0. Therefore we can write these recurrence relations like this.

Let n be the number of leaves in the NAND tree which has to be a power of 2 (n = 2^k):

    * P0(n) = P1(n/2) x P1(n/2)
    * P1(n) = 1 - P0(n)

The base case for these probabilities is for n = 2^0 = 1 in which P1 and P0 will be:

P1(1) = 0.5

P0(1) = 0.5

As the probability of a single leaf being 0 or 1 is 50% for both cases.

We then implemented a simple static function inside the NANDTree class to evaluate the probability of a tree evaluation given n = 2^k leaves. After testing these functions with different inputs, we found that the probability of a tree with n = 2^15 or 32768 leaves evaluating one rounded to 1 in our environment.

