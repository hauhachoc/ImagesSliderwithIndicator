using System.Linq;
using Android.App;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ImageSlider.Adapter
{
    public class ViewPagerAdapter: PagerAdapter
    {
        private readonly Context _context;
        private LayoutInflater _layoutInflater;
        private readonly int[] _images = {Resource.Drawable.slide_adobo,
            Resource.Drawable.slide_empad,
            Resource.Drawable.slide_teryaki,
            Resource.Drawable.slide_pchop,
            Resource.Drawable.slide_plion};

        public ViewPagerAdapter(Context context)
        {
            _context = context;
        }

        public override Object InstantiateItem(ViewGroup container, int position)
        {
            _layoutInflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            var view = _layoutInflater.Inflate(Resource.Layout.frag_content, null);
            var imageView = view.FindViewById<ImageView>(Resource.Id.img_slide);
            imageView.SetImageResource(_images[position]);
            var viewPager = (ViewPager) container;
            viewPager.AddView(view, 0);
            return view;
        }

        public override bool IsViewFromObject(View view, Object @object)
        {
            return view == @object;
        }

        public override int Count => _images.Count();
        public override void DestroyItem(ViewGroup container, int position, Object @object)
        {
            var viewPager = (ViewPager) container;
            var view = (View) @object;
            viewPager.RemoveView(view);
        }
    }
}