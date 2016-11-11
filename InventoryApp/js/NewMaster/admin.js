jQuery(document).ready(function($){

    if( $('input[name=use_div_meta]').attr('checked') == 'checked' ){
      $('.extended').fadeIn();
    }else{
      $('.extended').fadeOut();
    }

    $('input[name=use_div_meta]').change( function(){
      
      if( $('input[name=use_div_meta]').attr('checked') == 'checked' ){
          $('.extended').fadeIn();
        }else{
          $('.extended').fadeOut();
        }
    })


}); // main jquery container
