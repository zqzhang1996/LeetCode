using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0653
{
    // Definition for a binary tree node.
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        public bool FindTarget(TreeNode root, int k)
        {
            inOrder(root);
            foreach (int num in nums)
            {
                if (nums.Contains(k - num) && k - num != num) return true;
            }
            return false;
        }
        HashSet<int> nums = new HashSet<int>();
        void inOrder(TreeNode root)
        {
            if (root == null) return;
            inOrder(root.left);
            nums.Add(root.val);
            inOrder(root.right);
        }
    }
}
