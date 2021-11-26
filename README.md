# PromotionEngine
Promotion engine for promotional products

**1. PromotionEngine.Demo**<br/>
  This project can be use to see demo of the Promotional Engine implementation. Simply add the orders and get total value of the orders with all the promotions applied.

**2. PromotionEngine.Interface**<br/>
  Contains all the interfaces required to add Order, Product and Promotions

**3. PromotionEngine.Library**<br/>
  Contains implementation of all the interfaces.<br/><br/>
    **a. Promotion**<br/>
      It is an abstract class for all the current Promotion types. We can implement this class for future promotion types.<br/><br/>
    **b. SingleProductMultiQuantityPromotion**<br/>
      It implements Promotion abstract class. It needs order list and it will just apply promotion on qualified orders and returns their total value including promotion value if any.<br/>
      This is Promotion for single product with multiple quantities e.g. 3 A's for 130 where unit price for one A is 50<br/><br/>
    **c. ComboProductPromotion**<br/>
      It implements Promotion abstract class. It needs order list and it will just apply promotion on qualified orders and returns their total value including promotion value if any.<br/>
      This is Promotion for multiple products with single/multiple quantities e.g. 1 C and 1 D for 30 Or 2 C's and 1 D for 45 where individual price for C & D is 20 each<br/><br/>
    **d. SeasonalPromotion**<br/>
      It implements IPromotionBuilder. We can pass data from backend api to generate current active promotions. Promotions could be multiple types as mentioned in c & d above.<br/><br/>
    **e. PromotionalEngine**<br/>
      This is the class where total value for all orders including promotions and regular price is calculated. It takes PromotionBuilder, generates active promotions and apply it to orders.<br/>

**4. PromotionEngine.Tests**<br/>
  Contains test cases for all implementation.<br/>
