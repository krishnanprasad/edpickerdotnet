(function($){var OpalListingHook=window.OpalListingHook={hooks:{action:{},filter:{}},addAction:function(action,callback,priority,context){this.addHook('action',action,callback,priority,context);},addFilter:function(action,callback,priority,context){this.addHook('filter',action,callback,priority,context);},doAction:function(action){this.doHook('action',action,arguments);},applyFilters:function(action){return this.doHook('filter',action,arguments);},removeAction:function(action,callback,priority,context){this.removeHook('action',action,callback,priority,context);},removeFilter:function(action,callback,context){this.removeHook('filter',action,callback,context);},addHook:function(hookType,action,callback,priority,context){priority=parseInt((priority||10),10);if(undefined==this.hooks[hookType][action]){this.hooks[hookType][action]=[];}var hooks=this.hooks[hookType][action];if(undefined==context){context=action+'_'+hooks.length;}this.hooks[hookType][action].push({callback:callback,priority:priority,context:context});},doHook:function(hookType,action,args){args=Array.prototype.slice.call(args,1);var value=args[0];if(undefined!=this.hooks[hookType][action]){var hooks=this.hooks[hookType][action];hooks.sort(function(a,b){return a['priority']-b['priority'];});for(var i=0;i<hooks.length;i++){var hook=hooks[i];if(typeof hook.callback=='string'){hook.callback=window[hook.callback];}if('action'==hookType){hook.callback.apply(hook.context,args);}else{value=hook.callback.apply(hook.context,args);}}}if('filter'==hookType){return value;}},removeHook:function(hookType,action,callback,priority,context){if(undefined!=this.hooks[hookType][action]){var hooks=this.hooks[hookType][action];for(var i=hooks.length-1;i>=0;i--){var hook=hooks[i];if(hook.priority==priority&&context==hook.context){hooks.splice(i,1);}}this.hooks[hookType][action]=hooks;}}};})(jQuery);(function($){window.CustomMarker=function CustomMarker(options){this.setValues(options);this.position=new google.maps.LatLng({lat:options.position.lat,lng:options.position.lng});this.div=null;}
CustomMarker.prototype=new google.maps.OverlayView();CustomMarker.prototype.draw=function(){var self=this;var div=this.div;if(!div){var div=document.createElement('div');div.style.position='absolute';div.className='opallisting-map-marker-holder';if(this.title){var title='map-marker-'+this.title;title=title.toLowerCase();title=title.replace(/ /g,'-');div.setAttribute('id',title);}var markerTemplate=wp.template('opallisting-marker-template');markerTemplate=markerTemplate({marker_icon:this.icon,color:this.color});$(div).append(markerTemplate);this.div=div;var panes=this.getPanes();panes.overlayImage.appendChild(this.div);google.maps.event.addDomListener(this.div,'click',function(event){google.maps.event.trigger(self,'click',event);});}var point=this.getProjection().fromLatLngToDivPixel(this.position);if(point){this.div.style.left=(point.x-this.div.offsetWidth/2)+'px';this.div.style.top=(point.y-this.div.offsetHeight)+'px';}};CustomMarker.prototype.remove=function(){if(this.div){this.div.parentNode.removeChild(this.div);this.div=null;}};CustomMarker.prototype.getPosition=function(){return this.position;};CustomMarker.prototype.getDraggable=function(){return false;};CustomMarker.prototype.getVisible=function(){return true;};})(jQuery);(function($){$('.opallisting-popup').on('click','.popup-header',function(e){e.preventDefault();$(this).parents('.opallisting-popup').toggleClass('active');return false;});$(document).on('click','.popup-close',function(e){e.preventDefault();$(this).parents('.opallisting-popup').removeClass('active');return false;});$(document).ready(function(){if(typeof magnificPopup=='function'){$('.place-gallery a').magnificPopup({type:'image',gallery:{enabled:true}});}$('.opallisting-carousel').each(function(){var config={navigation:typeof $(this).data('navigation')!=='undefined'?($(this).data('navigation')?true:false):false,slideSpeed:300,paginationSpeed:400,pagination:typeof $(this).data('pagination')!=='undefined'?($(this).data('pagination')?true:false):true,autoHeight:true,};var owl=$(this);if($(this).data('column')==1){config.singleItem=true;}else{config.items=$(this).data('column');}if($(this).data('desktop')){config.itemsDesktop=$(this).data('desktop');}if($(this).data('desktopsmall')){config.itemsDesktopSmall=$(this).data('desktopsmall');}if($(this).data('desktopsmall')){config.itemsTablet=$(this).data('tablet');}if($(this).data('tabletsmall')){config.itemsTabletSmall=$(this).data('tabletsmall');}if($(this).data('mobile')){config.itemsMobile=$(this).data('mobile');}$(this).owlCarousel(config);$('.opallisting-left',$(this).parent()).click(function(){owl.trigger('owl.prev');return false;});$('.opallisting-right',$(this).parent()).click(function(){owl.trigger('owl.next');return false;});});var sync1=$('#sync1');var sync2=$('#sync2');$('#sync2').on("click",".owl-item",function(e){e.preventDefault();var number=$(this).data("owlItem");sync1.trigger("owl.goTo",number);});$('.opallisting-need-login').on('click',function(e){e.preventDefault();$('.pbr-user-login, .opal-user-login').trigger('click');return false;});$('body').delegate('.btn-toggle-featured','click',function(e){e.preventDefault();var $this=$(this);$.ajax({type:'POST',url:opallistingJS.ajaxurl,data:'place_id='+$(this).data('place-id')+'&action=opallisting_toggle_featured_place',dataType:'json',success:function(data){if(data.status){$('[data-id="place-toggle-featured-'+$this.data('place-id')+'"]').removeClass('hide');$this.remove();}else{alert(data.msg);}}});return false;});$("#opallisting_user_frontchangepass").submit(function(e){e.preventDefault();var $this=$(this);$('.alert',$this).remove();$.ajax({type:'POST',url:opallistingJS.ajaxurl,dataType:'json',data:$(this).serialize()+'&action=opallisting_save_changepass',success:function(data){if(data.status==false){$this.find('.form-table').prepend($('<p class="alert alert-danger">'+data.message+'</p>'));}else{$this.find('.form-table').prepend($('<p class="alert alert-info">'+data.message+'</p>'));$('input',$this).val('');setTimeout(function(){$('.alert',$this).remove();},1000);}}});});$('.opallisting-load-more button').click(function(){var data=$(this).parent().data();var $this=$(this);$this.attr('disabled','disabled');$.ajax({type:'POST',url:opallistingJS.ajaxurl,data:jQuery.param(data),success:function(response){if(response){$('#'+data.related).append(response);var next=data.paged+1;$this.parent().attr('data-paged',next);$this.parent().data('paged',next);$this.attr('disabled',null);if(next==data.numpage+1){$this.remove();}}else{$this.remove();}}});return false;});$('.ajax-search-form select').change(function(){$('.ajax-search-form form.ajax-form').find('[name="paged"]').val(1);});$('form.ajax-change').each(function(){var $form=$(this);$('input, select',this).on('change',function(e){e.preventDefault();$form.submit();return false;});});$(document).on('click','.listing-type-item',function(e){e.preventDefault();var li=$(this).parent('li');li.toggleClass('active');var searchForm=$('#opallisting-search-form');var parent=$(this).parents('.opallisting-liting-type-ajax');searchForm.find('.listing-type').remove();parent.find('.active').each(function(){searchForm.append('<input type="hidden" name="type[]" value="'+$(this).find('a').data('id')+'" class="listing-type" />');});searchForm.submit();return false;});$(document).on('click','.opallisting-listing-types-list a',function(e){e.preventDefault();var id=$(this).data('type');var searchForm=$('#opallisting-search-form');$(this).toggleClass('active');if($(this).hasClass('active')){var html='<input type="hidden" name="types[]" value="'+id+'" id="place-type-'+id+'" />';searchForm.append(html);}else{searchForm.find('#place-type-'+id).remove();}searchForm.submit();return false;});$(document).on('change','.opallisting-tags-ajax input[type="checkbox"]',function(e){e.preventDefault();var searchForm=$('#opallisting-search-form');var value=$(this).val();if($(this).is(':checked')){searchForm.append('<input type="hidden" name="tag[]" value="'+value+'" id="tags-'+value+'" />');}else{searchForm.find('#tags-'+value).remove();}searchForm.submit();return false;});if($('.opallisting-sticky').length>0){$('.opallisting-sticky').each(function(){$(this).stick_in_parent($(this).data());});}$('.opallisting-selectize').selectize({allowEmptyOption:true,create:true,sortField:{field:'text',direction:'asc'},});});})(jQuery);(function($){$(document).on('click','.opallisting-fb-share',function(e){e.preventDefault();var url=$(this).attr('href');var fb_url='https://www.facebook.com/sharer/sharer.php?u='+url;window.open(fb_url,"FaceBook","width=600, height=400, scrollbars=no");return false;});$(document).on('click','.opallisting-google-share',function(e){e.preventDefault();var url=$(this).attr('href');var google_url='https://plus.google.com/share?url='+url;window.open(google_url,'GooglePlus','width=600, height=400');return false;});$(document).on('click','.opallisting-twitter-share',function(e){e.preventDefault();var url=$(this).attr('href'),image=$(this).attr('data-image'),share_text=$(this).attr('data-text'),url="https://twitter.com/intent/tweet?url="+url+"&text="+share_text;window.open(url,'Twitter','width=600,height=400');return false;});$(document).on('click','.opallisting-pinterest-share',function(e){e.preventDefault();var url=$(this).attr('href'),image=$(this).attr('data-image'),share_text=$(this).attr('data-text');var pin_url='http://pinterest.com/pin/create/button/?url='+url+'&media='+image+'&description='+share_text;window.open(pin_url,'Pinterest','width=600, height=400');return false;});

    var OpalListing_Single_Map = window.OpalListing_Single_Map = { map: null, mapOptions: {}, data: null, url: null, markers: [], size: null, center: null, infowindow: null, markerClusterer: null, mapEle: null, directionsService: null, directionsDisplay: null, currentPosition: null, initMap: function (data) { var that = this; that.data = data; that.url = data.url; that.size = new google.maps.Size(42, 57); var eleID = document.getElementById('place-map'); that.mapEle = $(eleID); if (window.devicePixelRatio > 1.5) { if (that.data.retinaIcon) { url = that.data.retinaIcon; size = new google.maps.Size(83, 113); } } that.center = new google.maps.LatLng(that.data.latitude, that.data.longitude); that.mapOptions = { center: that.center, zoom: 15, mapTypeId: google.maps.MapTypeId.ROADMAP, scrollwheel: false }; that.map = new google.maps.Map(eleID, that.mapOptions); that.markers.push(new CustomMarker({ map: that.map, position: { lat: parseFloat(that.data.latitude), lng: parseFloat(that.data.longitude) }, icon: that.data.marker_icon, title: that.data.place_title })); that.markerClusterer = new MarkerClusterer(that.map, that.markers, { ignoreHidden: true, maxZoom: 14, styles: [{ textColor: '#000000', url: '', height: 60, width: 50 }] }); that.directionsService = new google.maps.DirectionsService(); that.directionsDisplay = new google.maps.DirectionsRenderer({ map: that.map }); that.initEventHandler(); }, initEventHandler: function () { var that = this; var show_direction = document.querySelectorAll('.opallisting-show-direction')[0]; show_direction.addEventListener('click', function (e) { e.preventDefault(); var self = $(this); var overlay = self.parents('.place-map-section:first').find('.overlay'); if (overlay.length == 0) return; overlay.toggleClass('active'); }, false); var eleControls = document.querySelectorAll('.sub-controls a'); var overlay = that.mapEle.parents('.place-map-section:first').find('.overlay'); for (var i = 0; i < eleControls.length; i++) { var control = eleControls[i]; control.addEventListener('click', function (e) { e.preventDefault(); var self = $(this); var mode = self.data('mode'); if (that.markerClusterer.getMarkers().length > 1) { self.removeClass('active'); return; } $('.sub-controls a').removeClass('active'); self.toggleClass('active'); if (self.hasClass('active')) { var dist = that.markerClusterer.getMarkers()[0]; if (!that.currentPosition && !navigator.geolocation) { that.mapEle.removeClass('processing'); overlay.removeClass('active'); that.error(opallistingJS.i18n.map.SHARE_LOCATION); } else { that.mapEle.addClass('processing'); if (!that.currentPosition) { navigator.geolocation.getCurrentPosition(function (position) { var pos = { lat: position.coords.latitude, lng: position.coords.longitude }; that.currentPosition = pos; overlay.removeClass('active'); that.calculateAndDisplayRoute(that.currentPosition, dist, mode); }, function () { overlay.removeClass('active'); that.error(opallistingJS.i18n.map.SHARE_LOCATION); }); } else { overlay.removeClass('active'); that.calculateAndDisplayRoute(that.currentPosition, dist, mode); } } } else if (that.directionsDisplay) { that.directionsDisplay.setDirections(null); that.directionsDisplay = null; overlay.removeClass('active'); } }, false); } }, calculateAndDisplayRoute: function (current, dest, mode) { var that = this; var current = new google.maps.LatLng(current.lat, current.lng); var dest = new google.maps.LatLng(dest.position.lat(), dest.position.lng()); that.directionsService.route({ origin: current, destination: dest, avoidTolls: true, avoidHighways: false, travelMode: google.maps.TravelMode[mode] }, function (response, status) { if (status == google.maps.DirectionsStatus.OK) { that.directionsDisplay.setDirections(response); var infowindow2 = new google.maps.InfoWindow(); infowindow2.setContent(response.routes[0].legs[0].distance.text + "<br>" + response.routes[0].legs[0].duration.text + ' '); var total = response.routes[0].legs[0].steps.length; infowindow2.setPosition(response.routes[0].legs[0].steps[total / 2].end_location); infowindow2.open(that.map); } else { that.mapEle.removeClass('processing'); if (status == 'ZERO_RESULTS') { that.error(opallistingJS.i18n.map.ZERO_RESULTS); } else if (status == 'UNKNOWN_ERROR') { that.error(opallistingJS.i18n.map.UNKNOWN_ERROR); } else if (status == 'REQUEST_DENIED') { that.error(opallistingJS.i18n.map.REQUEST_DENIED); } else if (status == 'OVER_QUERY_LIMIT') { that.error(opallistingJS.i18n.map.OVER_QUERY_LIMIT); } else if (status == 'NOT_FOUND') { that.error(opallistingJS.i18n.map.NOT_FOUND); } else if (status == 'INVALID_REQUEST') { that.error(opallistingJS.i18n.map.INVALID_REQUEST); } else { that.error(opallistingJS.i18n.map.ERROR + status); } } }); }, error: function (message) { var that = this; var html = wp.template('map-error-message')({ 'message': message }); that.mapEle.find('.overlay').remove(); that.mapEle.append(html); that.mapEle.find('.overlay').addClass('active'); document.getElementById('opallisting-close-map-message').addEventListener('click', function (e) { e.preventDefault(); that.closeError(); }, false); }, closeError: function () { var that = this; that.mapEle.find('.overlay').remove(); } }; function initialize_place_street_view(data) { var placeMarkerInfo = data; var placeLocation = new google.maps.LatLng(placeMarkerInfo.latitude, placeMarkerInfo.longitude); var panoramaOptions = { position: placeLocation, pov: { heading: 34, pitch: 10 } }; panorama = new google.maps.StreetViewPanorama(document.getElementById('place-street-view-map'), panoramaOptions); } $(document).ready(function () { var placeLocation = null; if ($('#place-map').length > 0) { OpalListing_Single_Map.initMap($('#place-map').data()); } $('.google-map-tabs li a').click(function () { if ($(this).attr('href') == '#tab-google-map') { setTimeout(function () { OpalListing_Single_Map.initMap($('#place-map').data()); }, 300); } else if ($(this).hasClass('tab-google-street-view-btn')) { $('#place-search-places .btn-map-search').removeClass('active'); setTimeout(function () { initialize_place_street_view($('#place-map').data()); }, 300); } $(this).parent().parent().find('a').removeClass('active'); $(this).addClass('active'); $($(this).attr('href')).parent().find('.listing-tab-panel').removeClass('active'); $($(this).attr('href')).addClass('active'); return false; }); $('.opallisting-tiptip').tipTip({ 'attribute': 'data-tip', 'fadeIn': 50, 'fadeOut': 50, 'delay': 200 }); });
})(jQuery); (function ($) {
    $(document).ready(function () {
        $('.opallisting-place-gallery').each(function () { $(this).magnificPopup({ delegate: 'a', type: 'image', gallery: { enabled: true }, callbacks: function () { this.content.addClass('mfp-zoom-in'); } }); }); var mainGallery = $('#main-gallery'); var pGallery = $('#pagination-gallery'); mainGallery.owlCarousel({ singleItem: true, slideSpeed: 1000, navigation: true, pagination: false, afterAction: syncPosition, responsiveRefreshRate: 200, }); pGallery.owlCarousel({ items: 3, itemsDesktop: [1199, 10], itemsDesktopSmall: [979, 10], itemsTablet: [768, 8], itemsMobile: [479, 4], pagination: false, responsiveRefreshRate: 100, afterInit: function (el) { el.find(".owl-item").eq(0).addClass("synced"); mainGallery.find('.owl-prev').after(wp.template('opallisting-carousel-txt')({ current: 1, total: mainGallery.find('.item').length })); } }); function syncPosition(el) {
            var current = this.currentItem; pGallery.find(".owl-item").removeClass("synced").eq(current).addClass("synced")
if(mainGallery.data("owlCarousel")!==undefined){mainGallery.find('.owl-text').replaceWith(wp.template('opallisting-carousel-txt')({current:this.currentItem+1,total:mainGallery.find('.item').length}));center(current)}}pGallery.on("click",".owl-item",function(e){e.preventDefault();var number=$(this).data("owlItem");mainGallery.trigger("owl.goTo",number);});function center(number){var sync2visible=pGallery.data("owlCarousel").owl.visibleItems;var num=number;var found=false;for(var i in sync2visible){if(num===sync2visible[i]){var found=true;}}if(found===false){if(num>sync2visible[sync2visible.length-1]){pGallery.trigger("owl.goTo",num-sync2visible.length+2)}else{if(num-1===-1){num=0;}pGallery.trigger("owl.goTo",num);}}else if(num===sync2visible[sync2visible.length-1]){pGallery.trigger("owl.goTo",sync2visible[1])}else if(num===sync2visible[0]){pGallery.trigger("owl.goTo",num-1)}}$(document).on('click','.opallisting-tab-v1 .tab a',function(e){e.preventDefault();var _this=$(this),_li=_this.parent(),_wraper=_this.parents('.opallisiting-nav-tabs'),_sections=_this.parents('.opallisting_place.version-1').find('.content-box'),_section=_this.attr('href');_wraper.find('li').removeClass('active');_sections.removeClass('active').removeClass('fade').removeClass('in');_li.addClass('active');$(_section).addClass('fade').addClass('in');});$(document).on('click','.opallisting-tab-v2 .tab a',function(e){e.preventDefault();var _this=$(this),_li=_this.parent(),_wraper=_this.parents('.opallisiting-nav-tabs'),_sections=_this.parents('.opallisting_place.version-1').find('.content-box'),_section=_this.attr('href');_wraper.find('li').removeClass('active');_li.addClass('active');$('html, body').animate({scrollTop:$(_section).offset().top-($(_section).innerHeight()-$(_section).height())},1000);});$(document).on('click','.user-actions .opallisiting-nav-tabs li a',function(e){e.preventDefault();var _this=$(this),_li=_this.parent(),_wraper=_this.parents('.user-actions'),_sections=_this.parents('.user-actions').find('.content-box'),_section=_this.attr('href');_wraper.find('li').removeClass('active');_li.addClass('active');_sections.addClass('hide').removeClass('fade').removeClass('in');$(_section).removeClass('hide').addClass('fade').addClass('in');return false;});window.opallisting_init_carousel=function opallisting_init_carousel(){var carousels=$('.opallisting-carousel');for(var i=0;i<carousels.length;i++){var carousel=$(carousels[i]);carousel.owlCarousel({items:carousel.data('items')?carousel.data('items'):5,pagination:carousel.data('pagination')==1?true:false,navigation:carousel.data('navigation')==1?true:false,lazyLoad:carousel.data('lazyLoad')==1?true:false,});}}
opallisting_init_carousel();$(document).on('submit','.opallisting-ajax-load-more-places',function(e){e.preventDefault();var form=$(this),parents=form.parents('.opallisting-places');$.ajax({url:opallistingJS.ajaxurl,type:'POST',data:form.serializeArray(),beforeSend:function(){form.attr('disabled',true);parents.addClass('processing');var html=wp.template('opallisting-loading')({});parents.append(html);}}).always(function(){parents.find('.opallisting-loading').remove();parents.removeClass('processing');form.attr('disabled',false);}).done(function(res){if(typeof res.status=='undefined')return;if(typeof res.html!=='undefined'){form.before(res.html);}if(res.status===false||typeof res.found_posts!=='undefined'&&res.found_posts==parents.find('article.type-opallisting_place').length){form.remove();}if(typeof res.paged!=='undefined')form.find('[name="paged"]').val(res.paged);});return false;});$('.opallisting-place-claim-button').magnificPopup({type:'inline',preloader:false,callbacks:{beforeOpen:function(){if($(window).width()<700){this.st.focus=false;}else{}},close:function(){$('.opallisting-claim-form').find('.opallisting-messages').remove();$('.opallisting-claim-form').find('input, textarea').each(function(){$(this).val('');});return true;}}});$(document).on('submit','.opallisting-email-share-form',function(e){e.preventDefault();var form=$(this);var button=form.find('.submit');var data=form.serializeArray();data.push({name:'uri',value:window.location.href});$.ajax({url:opallistingJS.ajaxurl,type:'POST',dataType:'json',data:data,beforeSend:function(){form.addClass('processing');form.find('.has-error').removeClass('has-error');form.find('.opallisting-messages').remove();if(typeof $.fn.button!=='undefined'){button.button('loading');}}}).always(function(){form.removeClass('processing');if(typeof $.fn.button!=='undefined'){button.button('reset');}}).done(function(data){if(typeof data.status==='undefined')return;if(typeof data.messages!=='undefined'){form.find('.body').after(data.messages);if(data.status===true){form.find('.opallisting-messages').delay(2000).queue(function(){$(this).remove();form.find('input, textarea').each(function(){$(this).val('');});$.magnificPopup.close();});}}if(typeof data.redirect!=='undefined'){window.location.href=data.redirect;}if(typeof data.fields!=='undefined'){for(var i=0;i<data.fields.length;i++){var fieldName=data.fields[i];form.find('[name="'+fieldName+'"]').parents('.form-row').addClass('has-error');}}});return false;});$(document).on('submit','.opallisting-claim-form',function(e){e.preventDefault();var form=$(this);$.ajax({url:opallistingJS.ajaxurl,type:'POST',data:form.serializeArray(),beforeSend:function(){form.addClass('processing');form.find('.has-error').removeClass('has-error');form.find('.opallisting-messages').remove();if(typeof $.fn.button!=='undefined'){button.button('loading');}}}).always(function(){form.removeClass('processing');if(typeof $.fn.button!=='undefined'){button.button('reset');}}).done(function(res){if(typeof res.status==='undefined')return;if(typeof res.messages!=='undefined'){form.find('.box-heading').after(res.messages);}if(typeof res.redirect!=='undefined'){window.location.href=res.redirect;}if(typeof res.fields!=='undefined'){for(var i=0;i<res.fields.length;i++){var fieldName=res.fields[i];form.find('[name="'+fieldName+'"]').parents('.form-row').addClass('has-error');}}});return false;});$(document).on('submit','.opallisting-toggle-friend',function(e){e.preventDefault();var form=$(this),button=form.find('.submit');$.ajax({url:opallistingJS.ajaxurl,type:'POST',data:form.serializeArray(),beforeSend:function(){form.addClass('processing');}}).always(function(){form.removeClass('processing');}).done(function(res){if(typeof res.status==='undefined')return;if(typeof res.html!=='undefined'){button.html(res.html);}if(typeof res.message!=='undefined'){form.prepend(res.message);form.find('.opallisting-messages').delay(2000).queue(function(){$(this).remove();});}if(typeof res.accept!=='undefined'){form.parents('.request:first').delay(2000).queue(function(){$(this).remove();});if(typeof res.avatar!=='undefined'){var widgets=$('.opallisting-user-friends-widget');for(var i=0;i<widgets.length;i++){var widget=$(widgets[i]);if(res.accept=='added'){if(widget.find('.opallisting-friends .avatar').length===0){widget.find('.opallisting-friends').html(res.avatar);}else{widget.find('.opallisting-friends').append(res.avatar);}}else if(typeof res.user_id!='undefined'){widget.find('.opallisting-friends .avatar[data-userid="'+res.user_id+'"]').remove();}}}}});return false;});$(document).on('submit','.opallisting-contact-form',function(e){e.preventDefault();var form=$(this),button=form.find('.submit');$.ajax({url:opallistingJS.ajaxurl,type:'POST',data:form.serializeArray(),beforeSend:function(){form.addClass('processing');form.find('.has-error').removeClass('has-error');form.find('.opallisting-messages').remove();if(typeof $.fn.button!=='undefined'){button.button('loading');}}}).always(function(){form.removeClass('processing');if(typeof $.fn.button!=='undefined'){button.button('reset');}}).done(function(res){if(typeof res.status==='undefined'){return;}if(res.status===false&&typeof res.fields!=='undefined'&&res.fields.length>0){for(var i=0;i<res.fields.length;i++){var input=form.find('[name="'+res.fields[i]+'"]').parents('.form-row:first').addClass('has-error');}}if(typeof res.message!=='undefined'){form.append(res.message);}form.find('.opallisting-messages').delay(2000).queue(function(){$(this).remove();});if(res.status===true){form.find('input[type="text"], input[type="email"], input[type="tel"], textarea').val('');}});return false;});});$(document).on('click','.opallisting-toggle-favorite',function(e){e.preventDefault();var _self=$(this),nonce=_self.data('nonce'),id=_self.data('id');$.ajax({url:opallistingJS.ajaxurl,type:'POST',data:{nonce:nonce,action:'opallisting_toggle_favorite',place_id:id,icon:_self.data('icon')},beforeSend:function(){_self.addClass('processing');}}).always(function(){_self.removeClass('processing');}).done(function(res){if(typeof res.status==='undefined')return;if(res.status===true&&typeof res.icon!=='undefined'){$('[data-icon="'+_self.data('icon')+'"][data-id="'+id+'"]').find('i').removeClass('fa-star-o').removeClass('fa-star').removeClass('fa-heart-o').removeClass('fa-heart').addClass(res.icon);}if(_self.parents('.my-favorite').length==1){window.location.reload();}});return false;});$('.opallisting-review-button').magnificPopup({type:'inline',preloader:false,callbacks:{beforeOpen:function(){},close:function(){$('#commentform').removeClass('mfp-hide').find('input[type="text"], input[type="email"], input[type="tel"], textarea').val('');$('#commentform').find('.form-row').removeClass('has-error');return true;}}});var search_actions=$('.opallisting-search-actions .action:not(.opallisting-need-login)');for(var i=0;i<search_actions.length;i++){var action=$(search_actions[i]);action.magnificPopup({callbacks:{beforeClose:function(){$('.opallisting-form').find('.opallisting-messages').remove();}}});}$(document).on('click','.opallisting-search-ajax-filter .title',function(e){e.preventDefault();var self=$(this);var parent=self.parent();self.toggleClass('active');parent.find('.item').toggleClass('hide');return false;});$(document).on('click','.opallisting-switch-layout',function(e){e.preventDefault();var self=$(this);var data=self.data();var parent=wrapper=self.parents('.opallisting-places-wrapper:first');if(parent.length==0&&(typeof data.archive!=='undefined'&&data.archive===1)){window.location.href=self.attr('href');return true;}var parent_data=wrapper.data();data=$.extend({},parent_data,data);var formData=$.merge($('#opallisting-search-form').serializeArray(),$('.opallisting-search-ajax-filter input').serializeArray());$.each(data,function(index,value){formData.push({name:index,value:value});});opallisting_load_places_layout(formData,wrapper);return false;});$(document).on('click','.opallisting-btn-group.sortable .btn',function(e){e.preventDefault();var self=$(this);var parent=self.parent();var menu=parent.find('.opallisting-dropdown-menu');menu.toggleClass('active');return false;});var sortable_loading=false;$(document).on('click','.opallisting-dropdown-menu a',function(e){e.preventDefault();var self=$(this);var wrapper=self.parents('.opallisting-places-wrapper:first');if(wrapper.length==0){window.location.href=self.attr('href');return true;}var data=self.serializeArray();var wrapper=self.parents('.opallisting-places-wrapper:first');var formData=$.merge(data,$.merge($('.opallisting-search-ajax-filter input').serializeArray(),$('#opallisting-search-form').serializeArray()));$.each(wrapper.data(),function(index,value){formData.push({name:index,value:value});});formData.push({name:'action',value:'opallisting_switch_layout'});formData.push({name:'nonce',value:wrapper.find('.opallisting-switch-layout:first').data('nonce')});formData.push({name:'opalsortable',value:self.data('opalsortable')})
opallisting_load_places_layout(formData,wrapper);return false;});var layout_loading=false;function opallisting_load_places_layout(data,wrapper,repaint){if(layout_loading){if(layout_loading.state()=='pending'){layout_loading.abort();}}layout_loading=$.ajax({type:'POST',url:opallistingJS.ajaxurl,data:data,beforeSend:function(){wrapper.addClass('processing');}}).always(function(){wrapper.removeClass('processing');}).done(function(res){if(wrapper.length===1){var winTop=jQuery(window).scrollTop();var EleTop=wrapper.offset().top;if(EleTop<winTop){$('body,html').animate({scrollTop:EleTop-($('#wpadminbar').length>0?$('#wpadminbar').height():0)});}}if(typeof res.html!=='undefined'){wrapper.replaceWith(res.html);}OpalListing_Places_Map_Layout.initMap();});}var OpalListing_Places_Map_Layout=window.OpalListing_Places_Map_Layout={map:null,initMap:function(){var that=this;var ele=$('.opallisting-places-map');var eleID=ele.attr('id');$('#'+eleID).opallisting_map({places:ele.data('places'),scrollwheel:true,scaleControl:true,draggable:true});return that;}}
$(document).ready(function(){OpalListing_Places_Map_Layout.initMap();});})(jQuery);