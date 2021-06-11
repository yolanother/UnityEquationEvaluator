using System;
using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Equation Evaluator/Variable References/Int")]
    public class IntVariableReference : SOVariableReference
    {
        public IntVariable value;

        public override double ReferenceValue => value.Value;
    }
}
