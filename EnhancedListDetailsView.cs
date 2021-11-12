using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace //insert namespace
{
    public sealed class EnhancedListDetailsView : Microsoft.Toolkit.Uwp.UI.Controls.ListDetailsView
    {
        public EnhancedListDetailsView()
        {
            this.DefaultStyleKey = typeof(EnhancedListDetailsView);
        }

        protected override void OnApplyTemplate()
        {

            Frame frame = GetTemplateChild("DetailsFrame") as Frame;
            this.DetailsFrame = frame;
            base.OnApplyTemplate();
        }


        public object ObjectToBringIntoView
        {

            get { return GetValue(ObjectToBringIntoViewProperty); }
            set { SetValue(ObjectToBringIntoViewProperty, value); }
        }

        public static readonly DependencyProperty ObjectToBringIntoViewProperty =
  DependencyProperty.Register(
     "ObjectToBringIntoView",
     typeof(object),
     typeof(EnhancedListDetailsView),
     new PropertyMetadata(null, new PropertyChangedCallback(OnObjectToBringIntoViewChanged)));

        private static void OnObjectToBringIntoViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null)
            {
                EnhancedListDetailsView eldv = d as EnhancedListDetailsView;
                if (e.NewValue != null)
                {
                    eldv.ObjectToBringIntoView = e.NewValue;
                    ListView lv = eldv.GetTemplateChild("MainList") as ListView;
                    lv.ScrollIntoView(e.NewValue, ScrollIntoViewAlignment.Leading);
                }
            }
        }
        
        public IObservableVector<object> GroupedCollectionItemsSource
        {
            get { return (IObservableVector<object>)GetValue(GroupedCollectionItemsSourceProperty); }
            set { SetValue(GroupedCollectionItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty GroupedCollectionItemsSourceProperty =
  DependencyProperty.Register(
     "GroupedCollectionItemsSource",
     typeof(IObservableVector<object>),
     typeof(EnhancedListDetailsView),
     new PropertyMetadata(null, new PropertyChangedCallback(OnGroupedCollectionItemsSourceChanged)));

        private static void OnGroupedCollectionItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null)
            {
                EnhancedListDetailsView eldv= d as EnhancedListDetailsView;
                eldv.GroupedCollectionItemsSource = (IObservableVector<object>)e.NewValue;
            }
        }


        public Frame DetailsFrame
        {
            get
            {
                return (Frame)GetValue(FrameProperty);
            }
            set
            {
                SetValue(FrameProperty, value);
            }
        }

        public static readonly DependencyProperty FrameProperty =
  DependencyProperty.Register(
     "DetailsFrame",
     typeof(Frame),
     typeof(EnhancedListDetailsView),
     new PropertyMetadata(null, new PropertyChangedCallback(FrameChanged)));

        private static void FrameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null)
            {
                EnhancedListDetailsView eldv = d as EnhancedListDetailsView;
                if (e.NewValue != null)
                {
                    eldv.DetailsFrame = (Frame)e.NewValue;
                }
            }
        }
        
    }
}
