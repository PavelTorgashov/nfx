//WARNING: This code was auto generated by template compiler, do not modify by hand!
//Generated on 28.01.2016 16:29:52 by NFX.Templatization.TextCSTemplateCompiler at SAMSON

using System; 
using System.Text; 
using System.Linq; 
using System.Collections.Generic; 

namespace id_63420_template_371 
{

 ///<summary>
 /// Auto-generated from template
 ///</summary>
 public  class wv_forms_test : NFX.Templatization.Template<object, NFX.Templatization.IRenderingTarget, object>
 {

     protected override void DoRender()
     {
       base.DoRender();
        Target.Write( wv_forms_test._4_S_LITERAL_0 );

     }


     #region Literal blocks content
        private const string _4_S_LITERAL_0 = @"<!DOCTYPE html>

<html lang=""en"" >
<head>
    <meta charset=""utf-8"" />
    <title>WV Data/RecordModel Unit Test</title>
    <script src=""wv.js"" ></script>
    <script src=""wv.gui.js"" ></script>
    <script src=""jquery-2.1.4.min.js"" ></script>

    <style>
        body {
            font-family: Verdana;
            font-size: 12px;
        }
        .fView {
            display: block;
            border: 1px solid #fefeb0;
            padding: 4px;
        }
        label {
            margin: 4px;
            display: inline-block;
        }
        fieldset {
            border: 1px solid #bfbfbf;
        }

        .wvError {
            color: yellow;
            background: #ff8080;
        }
        .wvRequired {
            font-weight: bold;
        }

        .wvModified {
            border-bottom: 2px solid #0000ff;
        }


        .wvDialogBase {
            display: block;
            position: fixed;
            background: #3866de;
            border: 1px solid #808080;
            border-radius: 4px;
            padding: 6px;
            color: white;
            box-shadow: 6px 6px 10px #888888;
        }

        .dlgYellow{ background: #ffff00;  }
        .dlgGreen {
            background: linear-gradient(to bottom, #bfd255 0%,#8eb92a 50%,#588701 51%,#9ecb2d 100%);
        }

        .wvDialogTitle {
            background: #2020c0;
            color: white;
            font-size: 1.37em;
            font-weight: bold;
            padding: 4px;
            border-radius: 4px;
        }

        .dlgYellow > .wvDialogTitle {
            background: red;
        }

        .dlgGreen > .wvDialogTitle {
            background: linear-gradient(to bottom, #45484d 0%,#000000 100%);
        }

        .wvDialogContent {
            display: block;
            background: #fefef0;
            color: black;
            border: 1px solid #7070ff;
            padding: 4px;
            margin-top: 6px;
            border-radius: 4px;
            overflow: auto;
        }

        .wvToast {
            display: block;
            position: fixed;
            background: black;
            border: 1px solid #808080;
            width: auto;
            padding: 8px;
            top: 45%;
            left: 50%;
            color: white;
            box-shadow: 2px 2px 10px #888888;
        }

        .wvToast_warning {
            display: block;
            position: fixed;
            background: yellow;
            border: 1px solid #bcbc00;
            width: auto;
            padding: 8px;
            top: 45%;
            left: 50%;
            color: black;
            box-shadow: 2px 2px 10px #888888;
        }

        .wvToast_error {
            display: block;
            position: fixed;
            background: #ff2020;
            border: 1px solid #ff8080;
            width: auto;
            padding: 8px;
            top: 45%;
            left: 50%;
            color: white;
            box-shadow: 2px 2px 10px #888888;
        }

        .wvCurtain {
            background:url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAYAAACp8Z5+AAAAF0lEQVQImWNgQAW+cAKJxs3xZWBgYAAANwIBz+0UkPgAAAAASUVORK5CYII=) repeat;
        }

        input[type=text],input[type=date],input[type=datetime],input[type=tel],select{
            width: 100%;
            background-color: #f0f0e0;
            border: 1px solid #e0e0e0;
        }

        input[type=text]:focus,input[type=date]:focus,input[type=datetime]:focus,input[type=tel]:focus,select:focus{
            background-color: #ffffc0;
            border: 1px solid #808080;
        }

        input[type=text]:disabled,input[type=date]:disabled,input[type=datetime]:disabled,input[type=tel]:disabled,select:disabled{
            background-color: #e0e0e0;
            color: #b0b0b0;
            border: 1px solid #808080;
        }


        .wvPuzzle {
            display: inline-block;
            width: auto;
        }
        .wvPuzzleHelp {
            display: block;
            border-top-left-radius: 12px;
            border-top-right-radius: 12px;
            background: #ff7070;
            color: white;
            border: 1px solid #808080;
            border-bottom: none;
            padding: 6px;
            font-size: 0.75em;
        }
        .wvPuzzleQuestion {
            display: block;
            border-top: none;
            border-bottom: none;
            background: #ff7070;
            color: white;
            border-left: 1px solid #808080;
            border-right: 1px solid #808080;
            padding: 6px;
            font-size: 1.2em;
            font-weight: bold;
        }

        .wvPuzzleInputs {
            display: block;
            border-top: none;
            border-bottom: none;
            background: #d0d0ff;
            border-left: 1px solid #808080;
            border-right: 1px solid #808080;
            padding: 4px;
        }

        .wvPuzzleInputs > input[type=""text""]:disabled {
            font-size: 2em;
            font-weight: bold;
            color: blue;
            background: white;
            width: 65%;
            height: 40px;
            padding: 0px;
            padding-left: 8px;
            padding-right: 8px;
            letter-spacing: 6px
        }
        .wvPuzzleInputs > button {
            font-size: 1.2em;
            font-weight: bold;
            width: 20%;
            height: 40px;
            float: right;
        }

        .wvPuzzleImg {
            display: block;
            border-bottom-left-radius: 12px;
            border-bottom-right-radius: 12px;
            background: #f8f8f8;
            border: 1px solid #808080;
            padding: 4px;
        }

        .wvPuzzleImg > img { margin-top: -20px; margin-bottom: -10px;  }



    </style>

    <script>
    </script>


</head>
<body>

   <h1>WAVE Form Test</h1>
  
    <form data-wv-rid=""V1"">

        <div class=""fView"" data-wv-fname=""FirstName""></div>
        <div class=""fView"" data-wv-fname=""MiddleName""></div>
        <div class=""fView"" data-wv-fname=""LastName""></div>
        <div class=""fView"" data-wv-fname=""LastName""></div>
        <div class=""fView"" data-wv-fname=""Age""></div>
        <div class=""fView"" data-wv-fname=""DateOfCall""></div>
        <div class=""fView"" data-wv-fname=""Phone""></div>
        <div class=""fView"" data-wv-fname=""Helper""></div>
        <div class=""fView"" data-wv-fname=""Registered""></div>
        <div class=""fView"" data-wv-fname=""Registered""></div>
        <div class=""fView"" data-wv-fname=""MusicType""></div>
        <div class=""fView"" data-wv-fname=""MusicType"" data-wv-ctl=""text""></div>
        <div class=""fView"" data-wv-fname=""Various""></div>
        <div class=""fView"" data-wv-fname=""Various"" data-wv-ctl=""radio""></div>
        <div class=""fView"" data-wv-fname=""Consent""></div>
        <div class=""fView"" data-wv-fname=""Notes""></div>

    </form>

    <script>
        var REC = null;
        var RVIEW = null;
         REC =  new WAVE.RecordModel.Record(
                                            {ID: 'R1', 
                                             fields: [
                                              {def: {Name: 'FirstName', Type: 'string', Required: true, DefaultValue: 'Bob', Placeholder: 'Your First Name', Case: WAVE.RecordModel.CASE_CAPS}, val: 'Sunil'},
                                              {def: {Name: 'MiddleName', Type: 'string', Required: false, Placeholder: 'Your Middle Name', Case: WAVE.RecordModel.CASE_CAPS}, val: 'Borman'},
                                              {def: {Name: 'LastName', Type: 'string', Required: true, DefaultValue: 'Dole', Case: WAVE.RecordModel.CASE_CAPS}, val: 'Buchan'},
                                              {def: {Name: 'Age', Type: 'int', MinValue: 10}, val: 127},
                                              {def: {Name: 'DateOfCall', Type: 'date', Kind: WAVE.RecordModel.KIND_DATETIME}, val: ""5/11/1980 14:35""},
                                              {def: {Name: 'Phone', Type: 'string', Kind: WAVE.RecordModel.KIND_TEL}, val: ""(216) 292-1030""},
                                              {def: {Name: 'Registered', Type: 'bool'}, val: true},
                                              {def: {Name: 'Consent', Type: 'bool', Required: true}},
                                              {def: {Name: 'Notes', Type: 'string', Size: 52, Required: true}, val: ""Privet!""},

                                              {def: {Name: 'MusicType', Type: 'string', Case: WAVE.RecordModel.CASE_UPPER,
                                                     LookupDict: {HRK: ""Hard Rock"", CRK: ""Classic Rock"", RAP: ""Rap"", CMU: ""Classical music""}}},

                                              {def: {Name: 'Various', Type: 'string', Required: true, Placeholder: 'Your Various Statuses',
                                                     Case: WAVE.RecordModel.CASE_UPPER,
                                                     LookupDict: {CAR: ""Has a car"",
                                                                  SMK: ""Smokes"",
                                                                  PAR: ""Party member"",
                                                                  LAL: ""Lived alone"",
                                                                  HMD: ""Hates mobile devices"",
                                                                  FAS: ""Former Alaskan Subsidary"",
                                                                  SEX: ""Space explorer""}}}
                                             ]}
                                            );
         RVIEW = new WAVE.RecordModel.RecordView(""V1"", REC);
    </script>

    <button onclick=""REC.fldLastName.value(new Date())"">Set Date</button>
    <button onclick=""REC.fldNotes.value('Salut\nJoe Dassin!')"">Set Notes</button>
    <button onclick=""REC.fldLastName.visible(!REC.fldLastName.visible())"">Visible LastName</button>
    <button onclick=""REC.applyDefaultValue(false)"">Apply Defaults</button>
    <button onclick=""REC.applyDefaultValue(true)"">Apply Defaults FORCE</button>
    <button onclick=""REC.fldMusicType.value('WRONG')"">Set Wrong Music Type</button>
    <button onclick=""alert(JSON.stringify(REC.data()));"">Show Data</button>
    <button onclick=""alert(REC.validate()); alert(REC.allValidationErrorStrings());"">Validate</button>
    <button onclick=""RVIEW.buildViews();"">Build</button>
    <button onclick=""RVIEW.destroyViews();"">Destroy</button>
    <button onclick=""REC.resetModified();/*RVIEW.buildViews();*/"">Reset Modified</button>
    <button onclick=""REC.fldLastName.readonly(!REC.fldLastName.readonly())"">Read-Only LastName</button>
    <button onclick=""REC.fldRegistered.readonly(!REC.fldRegistered.readonly())"">Read-Only Registered</button>
    <button onclick=""REC.fldMusicType.readonly(!REC.fldMusicType.readonly())"">Read-Only MusicType</button>
    <button onclick=""REC.fldLastName.applicable(!REC.fldLastName.applicable())"">Applicable LastName</button>
    <button onclick=""REC.fldRegistered.applicable(!REC.fldRegistered.applicable())"">Applicable Registered</button>
    <button onclick=""REC.fldLastName.required(!REC.fldLastName.required())"">Required</button>
    <button onclick=""REC.fldVarious.lookupDict().LENIN = 'DaLenin!'; REC.fldVarious.eventInvoke(WAVE.RecordModel.EVT_INTERACTION_CHANGE, '','');"">Add Lenin</button>
    <button onclick=""delete REC.fldVarious.lookupDict().LENIN; REC.fldVarious.eventInvoke(WAVE.RecordModel.EVT_INTERACTION_CHANGE, '','');"">Remove Lenin</button>
    <hr>
    <button onclick=""WAVE.GUI.toast('Message 1')"">Toast 1</button>
    <button onclick=""WAVE.GUI.toast('Message 2')"">Toast 2</button>
    <button onclick=""WAVE.GUI.toast('Message 3 which contains much more text in comparison to the prior two messages')"">Toast 3</button>
    <button onclick=""WAVE.GUI.toast('This is a warning text','warning')"">Warning</button>
    <button onclick=""WAVE.GUI.toast('This is a text for the error message','error')"">Error</button>

    <button onclick=""WAVE.GUI.curtainOn(); WAVE.GUI.toast('Toast above curtain','warning'); setTimeout(function(){WAVE.GUI.curtainOff();}, 2700);"">CurtainOn</button>
    <hr>

    <script>

        function showDialog1(){
           var dlg = new WAVE.GUI.Dialog({
                    title: 'This is a test dialog',
                    content: 'Lenin loved mushrooms<br>He gathered them in the forest<br>'+
                             'Another line<br>'+
                             '<button onclick=""WAVE.GUI.currentDialog().cancel()"">Dismiss</button>'
                    });
           setTimeout(function(){dlg.cancel();}, 3000);
        }

        function showDialog2(cssClass){
           var dlg = new WAVE.GUI.Dialog({
                    title: 'Shipping and Delivery Selection',
                    content: 'Shipping options<br>He gathered them in the forest WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A<br>A',
                    widthpct: 75,
                    heightpct: 90,
                    cls: cssClass
                    });
          // setTimeout(function(){dlg.cancel();}, 3000);
        }

        function showManyDialogs(){
            var dlg1 = dlg = new WAVE.GUI.Dialog({
                    title: 'Root dialog',
                    content: 'This is an example of how to show one dialog from another.<br>'+
                             'When you click on ""Show Another"" it will display yet another dialog box on top of this one.<br>'+
                             'This behavior may be necessary in the nested applications, for example<br>'+
                             'when a confirmation box needs to be shown<hr>'+
                             '<button onclick=""showDialog1()"">Show Another</button>&nbsp;'+
                             '<button onclick=""WAVE.GUI.currentDialog().cancel()"">Close This</button>',
                    cls: ""dlgGreen""
                    });

        }

    </script>


    <button onclick=""showDialog1()"">Show Dialog 1</button>
    <button onclick=""showDialog2('dlgYellow')"">Show Dialog Yellow</button>
    <button onclick=""showDialog2('dlgGreen')"">Show Dialog Green</button>

    <button onclick=""showManyDialogs()"">Show Many</button>

    <br><br>
    <div id=""divPuzzle"" class=""wvPuzzle""></div>

    <script>
        
        var pk = new WAVE.GUI.PuzzleKeypad(
           {
             DIV: WAVE.id(""divPuzzle""),
             Image: ""http://nfx.io/mvc/tester/captcha"",
            // Help: ""SECURITY"",
            // Question: ""Who is this?<br><img src='http://4.bp.blogspot.com/_smy9-F4TJUU/SyqxO0hwvFI/AAAAAAAAAIg/ULSDlQLgi54/S220/italenin.png'/>""
            // Question: ""What is this?<br><img style='width: 128px;' src='http://live.regnumchristi.org/wp-content/uploads/2012/10/red-moon.jpg'/>""
             Question: ""Your PIN?""
            // Question: ""Punch-in every second letter of 'KOMBIMAN'?""
            //   Question: ""Fife pluz for iz?""
            // Question: ""What is the SEARS motto?<br><iframe width='128' height='72' src='http://www.youtube.com/embed/4SFZ-jU5chU' frameborder='0' allowfullscreen></iframe>""
           });
    

    </script>

    <button onclick=""alert(pk.jsonValue())"">SHOW Data</button>

</body>
</html>"; 
     #endregion

 }//class
}//namespace
