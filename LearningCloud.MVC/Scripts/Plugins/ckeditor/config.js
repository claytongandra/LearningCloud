/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
         { name: 'document', groups: ['mode', 'document', 'doctools'] },
         { name: 'clipboard', groups: ['clipboard', 'undo'] },
         { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
         { name: 'forms', groups: ['forms'] },
         '/',
         { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
         { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
         { name: 'links', groups: ['links'] },
         { name: 'insert', groups: ['insert'] },
         '/',
         { name: 'styles', groups: ['styles'] },
         { name: 'colors', groups: ['colors'] },
         { name: 'tools', groups: ['tools'] },
         { name: 'others', groups: ['others'] },
         { name: 'about', groups: ['about'] }
    ];
    //// Remove some buttons provided by the standard plugins, which are
    config.removeButtons = 'Select,Textarea,TextField,Radio,Checkbox,Button,ImageButton,HiddenField,Source,Save,Form,Flash';

    config.skin = 'moono-lisa,/Content/Plugins/ckeditor/skins/moono-lisa/';

    /*********************************************************************************************************************/
    //// Define changes to default configuration here.
    //// Toolbar configuration generated automatically by the editor based on config.toolbarGroups.
    ////config.toolbar = [
    ////    { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
    ////    { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
    ////    { name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
    ////    { name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
    ////    '/',
    ////    { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
    ////    { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
    ////    { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
    ////    { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
    ////    //'/',
    ////    { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
    ////    { name: 'colors', items: ['TextColor', 'BGColor'] },
    ////    { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
    ////    { name: 'others', items: ['-'] },
    ////    { name: 'about', items: ['About'] }
    ////];
	//// For complete reference see:
	//// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	//// The toolbar groups arrangement, optimized for two toolbar rows.
	//config.toolbarGroups = [
	//	{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
	//	{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
	//	{ name: 'links' },
	//	{ name: 'insert' },
	//	{ name: 'forms' },
	//	{ name: 'tools' },
	//	{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
	//	{ name: 'others' },
	//	'/',
	//	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
    //    { name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
	//	{ name: 'styles', groups: ['styles'] },
	//	{ name: 'colors' },
	//	{ name: 'about' }
	//];
	//config.extraPlugins = 'font';
	//config.extraPlugins = 'richcombo';
	//config.extraPlugins = 'listblock';
	//config.extraPlugins = 'panel';
	//config.extraPlugins = 'panelbutton';
	//config.extraPlugins = 'colordialog';
	//config.extraPlugins = 'floatpanel';
	//config.extraPlugins = 'button';
	//config.extraPlugins = 'colorbutton';
	//config.colorButton_enableMore = true;
	////config.colorButton_colors =
    ////'000,800000,8B4513,2F4F4F,008080,000080,4B0082,696969,' +
    ////'B22222,A52A2A,DAA520,006400,40E0D0,0000CD,800080,808080,' +
    ////'F00,FF8C00,FFD700,008000,0FF,00F,EE82EE,A9A9A9,' +
    ////'FFA07A,FFA500,FFFF00,00FF00,AFEEEE,ADD8E6,DDA0DD,D3D3D3,' +
    ////'FFF0F5,FAEBD7,FFFFE0,F0FFF0,F0FFFF,F0F8FF,E6E6FA,FFF';


	//// Remove some buttons provided by the standard plugins, which are
	//// not needed in the Standard(s) toolbar.
	//config.removeButtons = 'Underline,Subscript,Superscript';

	//// Set the most common block elements.
	//config.format_tags = 'p;h1;h2;h3;pre';

	//// Simplify the dialog windows.
	//config.removeDialogTabs = 'image:advanced;link:advanced';

	//config.skin = 'moono-lisa,/Content/Plugins/ckeditor/skins/moono-lisa/';
};
