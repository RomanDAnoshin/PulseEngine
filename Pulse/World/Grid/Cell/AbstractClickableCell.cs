using Pulse.System;

namespace Pulse.World.Grid.Cell
{
    public enum ClickableCellState
    {
        Normal,
        Hovered,
        Selected,
        Disabled
    }

    public abstract class AbstractClickableCell : AbstractCell
    {
        public delegate void ClickDelegate(ClickableCellState cellState);
        public event ClickDelegate Clicked;
        
        public ClickableCellState CellState = ClickableCellState.Normal;

        public override void Update(float dt)
        {
            UpdateState();
        }
        
        public virtual void UpdateState()
        {
            if (CellState != ClickableCellState.Disabled) {
                if (CellState == ClickableCellState.Selected) {
                    if (IsMouseInside()) {
                        if (WindowInput.WasMouseLeftButtonReleased) {
                            CellState = ClickableCellState.Hovered;
                            Clicked(CellState);
                        }
                    }
                } else {
                    if (IsMouseInside()) {
                        if (WindowInput.WasMouseLeftButtonReleased) {
                            CellState = ClickableCellState.Selected;
                            Clicked(CellState);
                        } else {
                            CellState = ClickableCellState.Hovered;
                        }
                    } else {
                        CellState = ClickableCellState.Normal;
                    }
                }
            }
        }

        public abstract bool IsMouseInside();
    }
}
