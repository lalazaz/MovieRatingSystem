using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace movieRatingSystem.Common;

public class MultilineStringEditor:UITypeEditor
{
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
        return UITypeEditorEditStyle.Modal;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

        if (editorService != null && value is string)
        {
            using (TextBox textBox = new TextBox())
            {
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Width = 300;
                textBox.Height = 200;
                textBox.Text = (string)value;

                editorService.DropDownControl(textBox);

                return textBox.Text;
            }
        }

        return base.EditValue(context, provider, value);
    }
}