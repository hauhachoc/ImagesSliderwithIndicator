
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using ImageSlider.Adapter;
using Fragment = Android.Support.V4.App.Fragment;

namespace ImageSlider
{
        public class FragKusina : Fragment, ViewPager.IOnPageChangeListener
        {
            private ViewPager _viewPager;
            private LinearLayout _sliderLayout;
            private int _dotsCount;
            private ImageView[] _dotsImage;
            private const int NonActd = Resource.Drawable.ic_nonact_dot;
            private const int ActiveD = Resource.Drawable.ic_nactve_dot;
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var rootView = inflater.Inflate(Resource.Layout.frag_kusina, container, false);
                _viewPager = rootView.FindViewById<ViewPager>(Resource.Id.vp_slide);
                _sliderLayout = rootView.FindViewById<LinearLayout>(Resource.Id.slider);
                var context = Activity.ApplicationContext;
                var viewPagerAdapter = new ViewPagerAdapter(context);
                _viewPager.Adapter = viewPagerAdapter;
                _dotsCount = viewPagerAdapter.Count;
                _dotsImage = new ImageView[_dotsCount];
                for (var i = 0; i < _dotsCount; i++)
                {
                    _dotsImage[i] = new ImageView(context);
                    _dotsImage[i].SetImageDrawable(ContextCompat.GetDrawable(context, NonActd));
                    var param = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                                                              ViewGroup.LayoutParams.WrapContent);
                    param.SetMargins(left: 8, top: 0, right: 8, bottom: 0);
                    _sliderLayout.AddView(_dotsImage[i], param);
                }
                _dotsImage[0].SetImageDrawable(ContextCompat.GetDrawable(context, ActiveD));
                _viewPager.AddOnPageChangeListener(this);
                return rootView;
            }
            public static FragKusina NewInstance()
            {
                return new FragKusina { Arguments = new Bundle() };
            }

            public void OnPageScrollStateChanged(int state)
            {

            }

            public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
            {

            }

            public void OnPageSelected(int position)
            {
                var context = Activity.ApplicationContext;
                for (var i = 0; i < _dotsCount; i++)
                {
                    _dotsImage[i].SetImageDrawable(ContextCompat.GetDrawable(context, NonActd));
                }
                _dotsImage[position].SetImageDrawable(ContextCompat.GetDrawable(context, ActiveD));
            }
        }

    }
 