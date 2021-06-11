using System;
using DoubTech.EquationEvaluator;
using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    [CreateAssetMenu(fileName="DoubleVariable", menuName="Equation Evaluator/Variables/Double")]
    public class DoubleValue : ScriptableObject
    {
        public double value;
    }

    [Serializable]
    public class DoubleVariable
    {
        public bool useConstant;
        public double constant;
        public DoubleValue variable;

        public double Value => useConstant ? constant : variable.value;
    }
}
