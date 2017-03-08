using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeCreation_Starter
{
	/// <summary>
	/// Represents a tree data structure
	/// with the ability to draw itself
	/// </summary>
	class Tree
	{
		// Constants for drawing
		private const float BranchAngle = 0.2f;
		private const float BranchLength = 25.0f;
		private const int BranchWidth = 2;

		// The root of the tree
		private TreeNode root;

		// Fields for drawing
		private SpriteBatch sb;
		private Texture2D pixel;
		private Color treeColor;

		/// <summary>
		/// Sets up the tree
		/// </summary>
		public Tree(SpriteBatch sb, Texture2D pixel, Color treeColor)
		{
			root = null;

			this.sb = sb;
			this.pixel = pixel;
			this.treeColor = treeColor;
		}

		/// <summary>
		/// Public facing Insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		public void Insert(int data)
		{
			// *** Fill in this method ****************************************
            if(root == null)
            {
                root = new TreeNode(data);
            }
            else
            {
                Insert(data, root);
            }
		}

		/// <summary>
		/// Private recursive insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		/// <param name="node">The node to attempt to insert into</param>
		private void Insert(int data, TreeNode node)
		{
			// *** Fill in this method ****************************************
            if(data < node.Data)
            {
                if(node.Left == null)
                {
                    node.Left = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Left);
                }
            }
            else if(data > node.Data)
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Right);
                }
            }
		}

		/// <summary>
		/// Public facing Draw method - Draws the tree at
		/// the specified position
		/// </summary>
		/// <param name="position">Where to start drawing the tree</param>
		public void Draw(Vector2 position)
		{
			// Anything to draw?
			if (root == null)
				return;

			// Begin and end the spritebatch once and do
			// all the drawing between those calls
			sb.Begin();
			Draw(root, position, 0);
			sb.End();
		}

		/// <summary>
		/// Draws the lines from this node to its children (if they exist)
		/// </summary>
		/// <param name="node">The starting node</param>
		/// <param name="position">The position of this node on the screen</param>
		/// <param name="angle">The current angle of the line</param>
		private void Draw(TreeNode node, Vector2 position, float angle)
		{
			// Calculates the next angles and positions for both left and right nodes
			// ** PASS THESE TO RECURSIVE CALLS OF THIS METHOD ***
			float leftAngle = angle - BranchAngle;
			Vector2 leftPos = position + Vector2.TransformNormal(Vector2.UnitY * -BranchLength, Matrix.CreateRotationZ(leftAngle));

			float rightAngle = angle + BranchAngle;
			Vector2 rightPos = position + Vector2.TransformNormal(Vector2.UnitY * -BranchLength, Matrix.CreateRotationZ(rightAngle));

			// ** Finish this method ******************************************
			// Remember to pass one of the two sets of variables above into each recursive call
            if(node.Left != null)
            {
                DrawLine(position, leftPos);
                Draw(node.Left, leftPos, leftAngle);
            }

            if (node.Right != null)
            {
                DrawLine(position, rightPos);
                Draw(node.Right, rightPos, rightAngle);
            }

        }

		/// <summary>
		/// Draws a line between two points by rotation a very
		/// thin rectangle which is the same length as the distance
		/// between the two points
		/// </summary>
		/// <param name="p1">One end of the line</param>
		/// <param name="p2">The other end of the line</param>
		private void DrawLine(Vector2 p1, Vector2 p2)
		{
			// Get the "length" of the line
			int dist = (int)Vector2.Distance(p1, p2);

			// Draw the line as a rotated rectangle
			sb.Draw(
				pixel,
				new Rectangle((int)p1.X, (int)p1.Y, dist, BranchWidth),
				null,
				treeColor,
				(float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X),
				Vector2.Zero,
				SpriteEffects.None,
				0);
		}

	}
}
