using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

//var inputImagePath = @"C:\Users\dan-alexandru.gligor\Documents\buletinAlexColor.jpg";// @"C:\Users\dan-alexandru.gligor\Documents\buletin_alex.jpg";// @"C:\Users\dan-alexandru.gligor\Downloads\alex_ci.jpg";



//void SeriaNr() 
//{
//    var seriaNr = @"C:\Users\dan-alexandru.gligor\Downloads\alex_ci_serie_nr.jpg";

//    var rw = 336;
//    var rh = 240;
//    var x_position = 194;
//    var y_position = 40;
//    var w_crop = 80;
//    var h_crop = 13;

//    CropImage.CropImag(seriaNr, inputImagePath, rw, rh, x_position, y_position, w_crop, h_crop);

//    var str = ImgToText.GetText(seriaNr);

//    var (seria, nr) = ImgToText.GetSeriaNr(str);

//    Console.WriteLine($"********************** \n    Seria:{seria}  Nr:{nr} \n ********************");
//}

//void CNP()
//{
//    var seriaNr = @"C:\Users\dan-alexandru.gligor\Downloads\alex_cnp.jpg";

//    var rw = 336;
//    var rh = 240;
//    var x_position = 118;
//    var y_position = 50;
//    var w_crop = 82;
//    var h_crop = 13;

//    CropImage.CropImag(seriaNr, inputImagePath, rw, rh, x_position, y_position, w_crop, h_crop);

//    var str = ImgToText.GetText(seriaNr);


//    Console.WriteLine($"********************** \n    CNP:{str}  \n ********************");
//}

//void Name()
//{
//    var seriaNr = @"C:\Users\dan-alexandru.gligor\Downloads\alex_name.jpg";

//    var rw = 336;
//    var rh = 240;
//    var x_position = 95;
//    var y_position = 69;
//    var w_crop = 110;
//    var h_crop = 13;

//    CropImage.CropImag(seriaNr, inputImagePath, rw, rh, x_position, y_position, w_crop, h_crop);

//    var str = ImgToText.GetText(seriaNr);


//    Console.WriteLine($"********************** \n    Name:{str}  \n ********************");
//}

//void Firstname()
//{
//    var seriaNr = @"C:\Users\dan-alexandru.gligor\Downloads\alex_firstname.jpg";

//    var rw = 336;
//    var rh = 240;
//    var x_position = 95;
//    var y_position = 88;
//    var w_crop = 110;
//    var h_crop = 11;

//    CropImage.CropImag(seriaNr, inputImagePath, rw, rh, x_position, y_position, w_crop, h_crop);

//    var str = ImgToText.GetText(seriaNr);


//    Console.WriteLine($"********************** \n    Firstame:{str}  \n ********************");
//}

//void Address()
//{
//    var seriaNr = @"C:\Users\dan-alexandru.gligor\Downloads\alex_address.jpg";

//    var rw = 336;
//    var rh = 240;
//    var x_position = 95;
//    var y_position = 140;
//    var w_crop = 200;
//    var h_crop = 24;

//    CropImage.CropImag(seriaNr, inputImagePath, rw, rh, x_position, y_position, w_crop, h_crop);

//    var str = ImgToText.GetText(seriaNr);


//    Console.WriteLine($"********************** \n    Address:{str}  \n ********************");
//}

//Address();
//Firstname();
//Name();
//SeriaNr();
//CNP();

//Console.ReadKey();

