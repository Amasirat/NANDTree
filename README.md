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

However if we take the Left-First solution and only check the left node of the tree. If the left node of the tree is false, we can skip evaluating its sibling and update the parent with the correct value, because (0 NAND 0 = 1 & 0 NAND 1 = 1). This is called *short-circuiting*.

However this solution is incomplete as there is a possiblity of the evaluation process to still take O(n) time regardless, that is when short-circuiting fails to take place at every point of evaluation.

Here we propose an algorithm that creates a NAND Tree in which the left-first algorithm fails to optimize the Evaluation.

## 1. O(n) left-first algorithm

Given a desired number of leaves, and the head node containing the required end value of the NAND tree (either 0 or 1), we can create a NAND tree in which the left subtree will always evaluate to 1. The reason is that the left-first algorithm short-circuits only if the left subtree has been evaluated to be 0 at any point of evaluation, Therefore making the left-first algorithm virtually identical to the naive solution in terms of running time if that condition is not met.

In order to do that, We need to start from the top to bottom creating it, therefore we require a node that contains the value the evaluation ends with.

In case the end evaluation is 1:

* The left and right values need to evaluate respectively to 1 and 0.

In case the end evaluation is 0:

* The left and right values need to both evaluate to 1.

Then we use recursion to dictate the evaluation of the left and right subtrees.

        -1
        / \
      -1  -1              This is an example of a NAND tree(n=4) that does not short-circuit
      / \ / \
     1  0 1  1

        -1
        / \               The four leaves are evaluated to 1 and 0 without short-circuit,
       1  0                 creating yet another NAND tree that does not shortcircuit             

         1                The evaluation of 1 has been done without short-circuiting 
                            as the left subtree remained 1

A summary of the above algorithm is done recursively in code like this:

* If the value of log2(leafcount) is equal to the height desired, return the current node

* If the value of the currently given node is 1, create a left node with the value of 1 and a right node with the value of 0, else if the value is 0 create both left and right nodes with the value of 1

* Then reset the value of the current node to -1 and first recursively do the same for the left and then the right subtree

The function of the algorithm described is implemented in Lib/NANDTreeCreator utility class under CreateNANDTreeUtil function.

At the end of the algorithm, it outputs a root node which contains leaf nodes with 1 or 0 values which due to the reason mentioned above will not be optimized with left-first algorithm.

### CreateNANDTree's Order of Complexity

This algorithm visits each parent node of the tree to create its leaves.

* LeafCount = 1: T(1) = 1 recursion call
* LeafCount = 2: T(2) = 3 recursion calls
* LeafCount = 3: T(3) = 5 recursion calls
* LeafCount = 4: T(4) = 7 recursion calls
* ...
* ...
* ...

* LeafCount = n: T(n) = 2n - 1

So using the constructed pattern, our algorithm does 2n-1 recursions. It does O(1) during each recursive call, creating a worst-case complexity of O(n).

## 2. Randomized-First Algorithm

Seeing the short-comings of the left-first algorithm, we can come up with another approach to mediate this issue. Instead of choosing the left subtree, choose a random subtree at each turn, hoping that our choice can short-circuit the evaluation at least once. This approach is called the *Randomized-First algorithm*.

The function for this algorithm is also implemented inside Lib.NANDTree.RandomizedFirstEvaluateUtil function.

The recurrence relation for this algorithm is like this:

T0(n) is the expected time complexity if the tree evaluates to 0
T1(n) is the expected time complexity if the tree evaluates to 1

    T0(n) = 2T1(n/2) + 1
    T1(n) = 0.5T1(n/2) + T0(n/2) + 1

The base cases are also denoted as so:

    T0(1) = 1
    T1(1) = 1

* While evaluating a node, if it is expected to evaluate to 0, Its expected time complexity will be the expected time complexity of each of its children subtrees evaluating to 1 plus its base case. Short-circuiting does not occur in this case, so each subtree needs to be evaluated in turn. There are 2 children subtrees where each subtree has n/2 leaf nodes, so 2T1(n/2) + 1 is accurate.

* While evaluating a node, if it is expected to evaluate to 1, There will be a few possibilities.

Based on the NAND truth table, There are three possible combinations of 1 and 0 which will evaluate to 1:

* 0 NAND 0
* 0 NAND 1
* 1 NAND 0

* Either we choose a subtree that evaluates to 0, which will short-circuit the tree giving us T0(n/2) + the base case.

* Or we choose a subtree that evaluates to 1, which will not short-circuit the tree and we have to visit the other child subtree as well. However due to the randomized nature of this algorithm. There is only a 50 percent chance of this occuring which makes it a 0.5T1(n/2). However if a child that evaluates to 1 has indeed been chosen, the other subtree will always evaluate to 0, therefore T0(n/2) time will also take place. The expected runtime will be half of the expected runtime of T1(n/2) plus the expected runtime of T0(n/2) plus the base case.

## 3. Proving T~0(n) = O(n^epsilon)

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
