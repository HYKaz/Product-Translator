<h1>Com IT .Net  Course Project</h1>
<h2>Product Translator</h2>
<h3>Introduction</h3>

<!-- <p>
  <strong><u>Instructor</u></strong><strong> :</strong>  <strong>Kyle</strong> Schmitz, <a href="mailto:krmschmitz@gmail.com">krmschmitz@gmail.com</a> <br />
  <strong><u>Student</u></strong><strong>:</strong> <strong>Syed</strong> Hasan Yasar <strong>Kazmi</strong>, <a href="mailto:hasan@hykaz.com">hasan@hykaz.com</a>  <br /> -->

<p>
  &ldquo;<em>Product  Translator</em>&rdquo; will be developed to facilitate foreign immigrants in Winnipeg,  who cannot understand English and are doing grocery; this application will  read-in the barcode of the product and will output the related multilingual  information. This software will provide following functions:
</p>
<ol>
  <li><span dir="ltr"> </span>User/Client  registration module including Admin at the backend. Client will be able to  register and set language and contact preferences.</li>
  <li><span dir="ltr"> </span>Products  database with descriptions in chosen languages. The information will include</li>
  <ol>
    <li><span dir="ltr"> </span>Product  Name.</li>
    <li><span dir="ltr"> </span>Price.</li>
    <li><span dir="ltr"> </span>Expiry/ Best  Before date/time. </li>
    <li><span dir="ltr"> </span>Description.</li>
    <li><span dir="ltr"> </span>Ingredients.</li>
    <li><span dir="ltr"> </span>Allergy/ Medical information [if  any – Optional].</li>
    <li><span dir="ltr"> </span> Ethnic Information [if any – Optional]. </li>
    <li><span dir="ltr"> </span>Other info</li>
  </ol>
</ol>
<ol>
  <li><span dir="ltr"> </span>User will be  able to scan barcode of any product on shelve in a grocery shop.</li>
  <li><span dir="ltr"> </span>Based on the  barcode, Product Translator will display product information in the chosen  language. To Perform this function following will be done</li>
  <ol>
    <li><span dir="ltr"> </span>Search the  database, if information is available display it.</li>
    <li><span dir="ltr"> </span>If not then  try using Google Translate or Bing to search information about the product in  user&rsquo;s language.</li>
  </ol>
  <li><span dir="ltr"> </span>TTS Module:  User will be able to listen to information instead of reading. TTS will used to  convert text of audio at runtime.</li>
  <li><span dir="ltr"> </span>Product  listings/Search Module: The website will list all the products in given  language. Users will be able to search information instead of scanning  barcodes. </li>
</ol>

<h2> Entity Relationships </h2>
<img src="https://github.com/HYKaz/Product-Translator/blob/master/erd.png" />


<h2>System Modules</h2>
<ul>
<li>Barcode [Data Matrix] Generator [Offline, WinForms, C#, .Net 4.6.1]</li>
<li>Barcode Reader [ASP.Net Core 2.1, C#]</li>
<li>Registration Module [ASP.Net Core 2.1, C#]</li>
<li>Scan Data Matrix Module  [ASP.Net Core 2.1, C#, 3Rd Party Library]</li>
<li>Search and Listings  [ASP.Net Core 2.1, C#]</li>
<li>Multilingual Text to Speech [ASP.Net, C#, MS TTS API, REST, Azure]</li>
<li>Admin Module</li>
<li>SQL Server Database</li>
</ul>

<h2>System Diagram Level 2</h2>
<img src="https://github.com/HYKaz/Product-Translator/blob/master/layout.png" />

<h2> Barcode Generator and Reader </h2>

As barcode generation and reading at runtime is one of the core modules of this project, so a dedicated generator software has been created that makes use of various third party free libraries. A commercial API/Library has been selected after through testing on Linear, QR and Data Matrix schemes to read the barcode with accuracy and least complixity.
<p> <strong> Screenshot Barcode Generator </strong> </p>
<img src="https://github.com/HYKaz/Product-Translator/blob/master/BarCodeGen_ScreenShot.png" />

<h2>Barcodes/ Data Matrix</h2>
I tried various barcode schemes including Linear Barcodes, QR Codes and DataMatrix for encoding the information about the Products, whose ID is required at runtime and was amazed to find that Linear Barcodes were hardly readable by various 3rd party barcode readers using webcam from the web but the most accurate were Data Matrix readings. So Data Matrix is selected as the barcode scheme of the choice.
DataMatrix code is a matrix 2D code that was developed by ID Matrix in 1987. It was registered to the ISS standard of AIMI in 1996 and the ISO/IEC standard in 2000. The details of this format are attached [ Click here to Download PDF ]

