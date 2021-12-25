﻿using NumericalGeometryLib.Computers;

namespace NumericalGeometryLib.Accelerators.BIH.Space2D.Traversal
{
    public struct AccBihLineTraversalData2D
    {
        public double OriginValue { get; }

        public double DirectionValue { get; }

        public double DirectionInvValue { get; }

        public double LineClipParameterValue0 { get; }

        public double LineClipParameterValue1 { get; }

        public bool IsDirectionPositive
        {
            get { return DirectionValue > 0; }
        }

        public bool IsDirectionNegative
        {
            get { return DirectionValue < 0; }
        }

        public bool IsDirectionZero
        {
            get { return DirectionValue == 0; }
        }


        internal AccBihLineTraversalData2D(IAccBihNode2D bihNode, LineTraversalData2D lineData)
        {
            var splitAxisIndex = bihNode.SplitAxisIndex;

            OriginValue = lineData.Origin[splitAxisIndex];
            DirectionValue = lineData.Direction[splitAxisIndex];
            DirectionInvValue = lineData.DirectionInv[splitAxisIndex];
            LineClipParameterValue0 = (bihNode.ClipValue0 - OriginValue) * DirectionInvValue;
            LineClipParameterValue1 = (bihNode.ClipValue1 - OriginValue) * DirectionInvValue;
        }
    }
}