using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0124
{
    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            maxPathSum = root.val;
            GetMaxPathSum(root);
            return maxPathSum;
        }
        int maxPathSum;
        int GetMaxPathSum(TreeNode root)
        {
            if (root == null) return 0;
            int left = GetMaxPathSum(root.left);
            int right = GetMaxPathSum(root.right);
            maxPathSum = Math.Max(maxPathSum, root.val + left + right);
            return Math.Max(Math.Max(root.val + left, root.val + right), 0);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
