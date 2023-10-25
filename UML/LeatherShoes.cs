class Manufacturer{
    public string brand;
    public string location;
    public int finance;
    public  Product[] products;
    public  Source[] sources;

    private  int Demand(int codeSupply){};
    //Получить сырьё, снять деньги из капитала
    public void getSupply(int codeSupply, Supplier S){      
            x = findSource(codeSupply)       
            int demand = Demand(x.materialCode);
            S.deviverSuplies(demand);
            x.quantity+=demand;
            finance -= S.bill;    
    }
    //Нахождение ваппродукт, увеличить его количество в вкладе, и снять сырья для производства
    public void Produce(int productCode, int quantity){
        Product x = findProduct(productCode);                                   //Нахождение
        if (x == null) break;
        foreach(Raw component in x.component){
            downSource(component.materialCode, component.unit)              //снять сыре в запасе
        }
        x.quantity += quantity;                                                 //+количество продукта
    }

    private Product findProduct(int code){
        foreach(Product product in products){
            if (product.productCode == code) {return product;}
        }
        return null;
    }
    private Source findSource(int code){
        foreach(Source source in sources){
            if (source.materialCodeode == code) {return source;}
        }
        return null;
    }
    private void downSource(int code, int quantity){
        Source forX = findSource(code);
        forX.quantity -= quantity;
    }
}
class Product{
    public int productCode;
    public string productName;
    public int quantity;
    public Raw[] components;
    private int produceCost;
    //установить цену продукта
    public int setPrice(int produceCost){
        int price;
        foreach(Raw component in components){
            price += component.cost*component.unit;
        }
        return price + produceCost;
    };

}

class Material{
    public int materialCode;
    public string materialName;
    public int cost;
}

class Source:Material{
    int quantity;
}
class Raw:Material{
    int unit;
}

class Supplier{
    public string nameSupplier;
    public int bill;
    private Source supply;
    public void deliverSupply(int demand){
            supply.quantity -= demand;
            bill += suplly.cost * demand;
    }S
}

class Distributor{
    public string nameDistributor;
    public int finance;
    public Product[] productsDistributor;
    public float profit = 0.2;                              //20% наценки
    public Retail[] retailers;
    public int distributorDemand(Product p) ;
    public void getProduct(Manufacturer M)
    {   
        int bill = 0;
        foreach(Product product in M.products)
        {   
            int demand = distributorDemand(product);                //Снят продукты из Производителя
            product.quantity-=demand;
            Product product D = findProductD(product.productCode)
                //Увеличивать продукты у Распределителя
            productD.quantity+=demand;    
            bill+=product.setPrice*demand;
        }
        M.finance+=bill;                //Платить производителю за продукты
        finance -= bill;                
    }
    
    public void sellToRetail(int codeProduct, int quantity, int codeRetail){       
        Retail  x = findRetail(codeRetail);
        Product fromRetail = x.findProductR(codeProduct);
        fromRetail.quantity+=quantity;
        Product toRetail = findProductD(codeProduct);
        toRetail.quantity-=quantity;                                             //Снять продукты при продажа
        int bill = toRetail.setPrice*quantity + (toRetail.setPrice*quantity)*profit;     //Прибыль у Распределителя           
        finance += bill;                                                        
    }

    private Product findProductD(int code){
        foreach(Product productD in productsDistributor){
            if (productD.productCode == code) {return productD;}
        }
        return null;
    }
    private Retail findRetail(int code){
     foreach(Retail retailer in retailers){
            if (retailer.codeRetail == code) {return retailer;}
        }
        return null;
    }
}

class Retail{
    public int codeRetail;
    public string addressRetail;
    public Product[] productInStock;
    public Product findProductR(int code){
        foreach(Product productR in productInStock){
            if(productR.codeProduct==code) {return ProductR;}
        }
        return null;
    }
}



