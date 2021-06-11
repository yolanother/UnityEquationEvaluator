using System;
using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    [CreateAssetMenu(fileName = "DoubleVariable", menuName = "Equation Evaluator/Variable References/Double")]
    public class DoubleVariableReference : SOVariableReference
    {
        public DoubleVariable value;

        public override double ReferenceValue => value.Value;
    }
}
