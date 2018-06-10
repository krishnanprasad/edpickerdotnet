( function( $ ) {
    // rentme_color_header_bg
    wp.customize( 'rentme_color_header_bg', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-header_bg-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-header_bg-js-customizer">#opal-masthead .header-main{background-color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_header_color
    wp.customize( 'rentme_color_header_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-header_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-header_color-js-customizer">.box-user i,.box-user a, .box-user span,#opal-masthead.header-v3 .search-box-wrapper a{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_cart_bg
    wp.customize( 'rentme_color_cart_bg', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-cart_bg-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-cart_bg-js-customizer">.box-top .box-title .mini-cart-items{background:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_cart_color
    wp.customize( 'rentme_color_cart_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-cart_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-cart_color-js-customizer">.box-top .box-title .mini-cart-items{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_menu_color
    wp.customize( 'rentme_color_menu_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-menu_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-menu_color-js-customizer">.navbar-mega-light .navbar-mega .navbar-nav li a, .navbar-mega-light .navbar-mega .navbar-nav li a .caret{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_submut_color
    wp.customize( 'rentme_color_submut_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-submut_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-submut_color-js-customizer">#opal-masthead.header-v3 .box-user .rentme-submission-place-url{border-color:'+newval.toString()+';}#opal-masthead.header-v3 .box-user a{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_product_name_color
    wp.customize( 'rentme_color_product_name_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-product_name_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-product_name_color-js-customizer">.product-block .name a{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_product_price_color
    wp.customize( 'rentme_color_product_price_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-product_price_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-product_price_color-js-customizer">.product-block .price *{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_product_pricesale_color
    wp.customize( 'rentme_color_product_pricesale_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-product_pricesale_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-product_pricesale_color-js-customizer">.product-block .price del span,.product-block .price del{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_footer_bg
    wp.customize( 'rentme_color_footer_bg', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-footer_bg-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-footer_bg-js-customizer">.opal-footer{background-color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_footer_color
    wp.customize( 'rentme_color_footer_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-footer_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-footer_color-js-customizer">.opal-footer{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_link_color
    wp.customize( 'rentme_color_link_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-link_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-link_color-js-customizer">.opal-footer ul.menu li a{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_heading_color
    wp.customize( 'rentme_color_heading_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-heading_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-heading_color-js-customizer">.opal-footer .widget .widget-title, .opal-footer .widget .widgettitle{color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_copyright_bg
    wp.customize( 'rentme_color_copyright_bg', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-copyright_bg-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-copyright_bg-js-customizer">.opal-copyright{background-color:'+newval.toString()+';}</style>');
            }
        } );
    } );
    // rentme_color_copyright_color
    wp.customize( 'rentme_color_copyright_color', function( value ) {
        value.bind( function( newval ) {
            $('#rentme-copyright_color-js-customizer').remove();
            if(newval != ''){
                $('body').append('<style id="rentme-copyright_color-js-customizer">.opal-copyright{color:'+newval.toString()+';}</style>');
            }
        } );
    } );

    /* OpalTool: inject code */
    /* OpalTool: end inject code */
} )( jQuery );