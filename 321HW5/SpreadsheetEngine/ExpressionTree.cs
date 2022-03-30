// <copyright file="ExpressionTree.cs" company="Linh Stitsel">
// Copyright (c) Linh Stitsel. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class for ExpressionTree. It can build the tree, evaluates the tree, and add variable nodes' names and values to a dictionary.
    /// </summary>
    public class ExpressionTree
    {
        private BaseNode root; // root of tree

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression tree builds based off an expression.</param>
        public ExpressionTree(string expression)
        {
            Variables = new Dictionary<string, double>();
            this.expression = expression;
            this.MakeTree(expression);
        }

        /// <summary>
        /// Gets or sets variable name and values.
        /// </summary>
        public static Dictionary<string, double> Variables { get; set; } // for name and value

        /// <summary>
        /// Gets tree expression.
        /// </summary>
        public string expression { get; private set; } // string expression

        /// <summary>
        /// Adds the name and value of the variable node to the dictionary.
        /// </summary>
        /// <param name="variableName">Name of variable node.</param>
        /// <param name="variableValue">Value of variable node.</param>
        public void SetVariable(string variableName, double variableValue) // add to dictionary library
        {
            try
            {
                Variables.Add(variableName, variableValue);
            }
            catch
            {
                Variables[variableName] = variableValue; // if variable already assigned then overwrite
            }
        }

        /// <summary>
        /// Evaluates the value of the root.
        /// </summary>
        /// <returns>Evaluated value of the root.</returns>
        public double Evaluate()
        {
            return this.root.Evaluate(); // return eval of root
        }

        private BaseNode MakeTree(string expression)
        {
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                switch (expression[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        OpNode node = new OpNode(expression[i]); // create operator node
                        if (this.root == null)
                        {
                            this.root = node; // assign as root if no root
                        }

                        node.Lhs = this.MakeTree(expression.Substring(0, i)); // recurse left subtree
                        node.Rhs = this.MakeTree(expression.Substring(i + 1)); // recurse right subtree
                        return node;
                }
            }

            // determine if node is constant or variable
            if (double.TryParse(expression, out double value))
            {
                return new ConstNode(value);
            }
            else
            {
                return new VarNode(expression);
            }
        }
    }
}