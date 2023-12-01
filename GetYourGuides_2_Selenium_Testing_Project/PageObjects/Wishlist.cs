using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class Wishlist
    {
        IWebDriver driver;
        public Wishlist(IWebDriver driver) 
        {
           this.driver=driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//p[@data-test-id='wishlist-group-list']")]
        public IList<IWebElement> WishListElements { get; set; }

        public bool CheckIfWishListCreated(string WLName)
        {
            foreach(IWebElement element in WishListElements)
            {
                if (element.Text == WLName)
                {
                    return true;
                    
                }
               
            }
            return false;
        }
    }

}

