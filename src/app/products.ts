export  class Products {
  public title: string;
  public author: string;
  public picture: string;
  public isbn: string;
  public date: string;
  public price: number;
  public quantity: number;

  constructor(title: string, author: string, picture:string,date: string, isbn: string, price:number, quantity:number){
    this.title = title;
    this.author = author;
    this.picture = picture;
    this.date= date;
    this.isbn = isbn;
    this.price = price;
    this.quantity = quantity;
  }

} 
