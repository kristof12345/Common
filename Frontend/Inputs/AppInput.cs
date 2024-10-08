﻿using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Web
{
    public class AppInput<T> : AppComponent
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public T Value { get; set; }

        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        [Parameter]
        public EventCallback OnInput { get; set; }

        [Parameter]
        public Expression<Func<T>> ValidationExpression { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ValidateOnInput { get; set; } = true;
    }

    public class StringInput : AppInput<string>
    {
        [Parameter]
        public InputType Type { get; set; } = InputType.Text;

        protected async Task OnValueEntered(InputEventArgs args)
        {
            Value = args.Value;
            await ValueChanged.InvokeAsync(args.Value);
            await OnInput.InvokeAsync();
        }
    }

    public class ListInput : AppInput<string>
    {
        [Parameter]
        public IEnumerable<string> Items { get; set; }

        protected async Task OnValueSelected(SelectEventArgs<string> args)
        {
            Value = args.ItemData;
            await ValueChanged.InvokeAsync(args.ItemData);
            await OnInput.InvokeAsync();
        }
    }
}
