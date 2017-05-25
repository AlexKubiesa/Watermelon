using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermelon.UI
{
    public partial class CardSelectionBox : Control
    {
        private static Control CURRENT_PARENT = null;
        private static List<CardSelectionBox> CURRENTLY_CHECKED = new List<CardSelectionBox>();

        public bool Checked
        {
            get { return _checked; }

            private set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (_checked)
                    {
                        BackColor = _checkedColor;
                        OnCheck(EventArgs.Empty);
                    }
                    else
                    {
                        BackColor = Color.Transparent;
                    }
                    Invalidate();
                }
            }
        }

        public bool QuickConfirm
        {
            get { return _quickConfirm; }
            set { _quickConfirm = value; } // Don't set this while one of these controls is selected - not sure what would happen.
        }

        public Color HoverColor
        {
            get { return _hoverColor; }
            set { _hoverColor = value; }
        }

        public Color CheckedColor
        {
            get { return _checkedColor; }
            set { _checkedColor = value; }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return _sizeMode; }
            set { _sizeMode = value; }
        }

        private Rectangle ImageRectangle
        {
            get
            {
                return ImageRectangleFromSizeMode(_sizeMode);
            }
        }

        private bool _checked;

        private bool _quickConfirm;

        private Color _hoverColor;

        private Color _checkedColor;

        private Image _image;

        private PictureBoxSizeMode _sizeMode;

        public CardSelectionBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            _checked = false;
            _quickConfirm = false;
            _hoverColor = Color.White;
            _checkedColor = Color.Black;
            _image = null;
            _sizeMode = PictureBoxSizeMode.Normal;
        }

        private Rectangle ImageRectangleFromSizeMode(PictureBoxSizeMode mode)
        {
            Rectangle result = ClientRectangle;
            result.X += Padding.Left;
            result.Y += Padding.Top;
            result.Width -= Padding.Horizontal;
            result.Height -= Padding.Vertical;

            if (_image != null)
            {
                switch (mode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        // Use image's size rather than client size. 
                        result.Size = _image.Size;
                        break;

                    case PictureBoxSizeMode.StretchImage:
                        // Do nothing, was initialized to the available dimensions. 
                        break;

                    case PictureBoxSizeMode.CenterImage:
                        // Center within the available space. 
                        result.X += (result.Width - _image.Width) / 2;
                        result.Y += (result.Height - _image.Height) / 2;
                        result.Size = _image.Size;
                        break;

                    case PictureBoxSizeMode.Zoom:
                        Size imageSize = _image.Size;
                        float ratio = Math.Min((float)ClientRectangle.Width / (float)imageSize.Width, (float)ClientRectangle.Height / (float)imageSize.Height);
                        result.Width = (int)(imageSize.Width * ratio);
                        result.Height = (int)(imageSize.Height * ratio);
                        result.X = (ClientRectangle.Width - result.Width) / 2;
                        result.Y = (ClientRectangle.Height - result.Height) / 2;
                        break;

                    default:
                        Debug.Fail("Unsupported PictureBoxSizeMode value: " + mode);
                        break;
                }
            }

            return result;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_image != null)
            {
                // Error and initial image are drawn centered, non-stretched.
                Rectangle drawingRect = ImageRectangle;

                pe.Graphics.DrawImage(_image, drawingRect);
            }
            base.OnPaint(pe);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (Checked)
            {
                // Confirm choice.
                OnConfirm(new SelectionEventArgs(CURRENTLY_CHECKED));
                foreach (CardSelectionBox box in CURRENTLY_CHECKED)
                {
                    box.Checked = false;
                }
                CURRENT_PARENT = null;
                CURRENTLY_CHECKED = new List<CardSelectionBox>();
                Select(); // So that the previously-selected box doesn't retain focus.
            }
            else if (Parent == null || Parent != CURRENT_PARENT)
            {
                // Clear the current selection first.
                foreach (CardSelectionBox box in CURRENTLY_CHECKED)
                {
                    box.Checked = false;
                }
                if (_quickConfirm)
                {
                    // Don't confirm, as there were other boxes selected.
                    CURRENT_PARENT = null;
                    CURRENTLY_CHECKED = new List<CardSelectionBox>();
                }
                else
                {
                    // Select the box.
                    Checked = true;
                    CURRENT_PARENT = Parent;
                    CURRENTLY_CHECKED = new List<CardSelectionBox>() { this };
                }
                Select();
            }
            else
            {
                if (_quickConfirm)
                {
                    if (CURRENTLY_CHECKED.Any())
                    {
                        // Don't confirm, as there are other boxes selected.
                        foreach (CardSelectionBox box in CURRENTLY_CHECKED)
                        {
                            box.Checked = false;
                        }
                        CURRENT_PARENT = null;
                        CURRENTLY_CHECKED = new List<CardSelectionBox>();
                    }
                    else
                    {
                        // Nothing is selected, so quick-confirm is OK
                        OnConfirm(new SelectionEventArgs(this));
                        CURRENT_PARENT = null;
                        CURRENTLY_CHECKED = new List<CardSelectionBox>();
                    }
                    
                }
                else
                {
                    // Add to selection.
                    Checked = true;
                    CURRENTLY_CHECKED.Add(this);
                }
                Select();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!_checked)
            {
                BackColor = _hoverColor;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_checked)
            {
                BackColor = Color.Transparent;
            }
        }

        protected virtual void OnCheck(EventArgs e)
        {
            Check?.Invoke(this, e);
        }

        protected virtual void OnConfirm(SelectionEventArgs e)
        {
            Confirm?.Invoke(this, e);
        }

        public event EventHandler Check;

        public event SelectionEventHandler Confirm;
    }
}
