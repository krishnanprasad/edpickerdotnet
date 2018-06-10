<?php
if ( ! defined( 'ABSPATH' ) ) {
	exit;
}

$main_class = opallisting_place_single_has_sidebar_left() && opallisting_place_single_has_sidebar_right() ? 'col-md-4 col-sm-4 col-xs-12' : ( opallisting_place_single_has_sidebar_left() || opallisting_place_single_has_sidebar_right() ? 'col-md-8 col-sm-8 col-xs-12' : 'col-md-12' );

get_header( apply_filters( 'rentme_fnc_get_header_layout', null ) );

?>

<div class="single-place-heading">
    <?php
        $bgimage = opallisting_place_single_head_bg();
        $classes[] = 'breadcrumb-place';

        if( $bgimage  ){
            $style[] = 'background-image:url(\''.($bgimage).'\')';
        }

        $estyle = !empty($style)? 'style="'.implode(";", $style).'"':"";

        $place = opallisting_get_place( get_the_ID() );
        $author = $place->getAuthor();
    ?>
    <header <?php printf( '%s', $estyle ) ?>>
        <div class="container">
            <a href="<?php echo esc_url( OpalListing_User::get_tab_url( $author->ID, 'places' ) ) ?>">
                <?php echo get_avatar( $author->ID, apply_filters( 'rentme_author_avatar_single_place', '100' ) ); ?>
            </a>
            <?php
                rentme_fnc_breadcrumbs();
            ?>
            <div class="row">
                <div class="col-md-9 col-xs-12 pull-left ">
                    <div class="favorite-button">
                        <?php opallisting_get_template( 'single-place/favorite-button' ); ?>
                    </div>
                    <div class="rating">
                        <?php opallisting_get_template( 'single-place/rating' ); ?>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 pull-right social-wrapper">
                    <div class="review-wrapper">
                        <?php opallisting_get_template( 'single-place/review-button' ); ?>
                    </div>
                    <div class="share-wrapper pull-right">
                        <?php opallisting_get_template( 'single-place/share' ); ?>
                    </div>
                    <div class="claim-wrapper pull-right">
                        <?php opallisting_get_template( 'single-place/claim' ); ?>
                    </div>
                    
                </div>
            </div>
        </div>
    </header>
</div>

<section id="main-container" class="site-main container" role="main">
    <div class="row">

        <div class="row">
            <?php if ( opallisting_place_single_has_sidebar_left() ) : ?>
                <aside class="sidebar sidebar-left col-md-4 col-sm-4 col-xs-12" itemscope="itemscope" itemtype="http://schema.org/WPSideBar">
                    <?php dynamic_sidebar( 'opallisting-place-sidebar-left' ); ?>
                </aside>
            <?php endif; ?>
            <main id="primary" class="content content-area <?php echo esc_attr( $main_class ) ?>">
                <div class="single-opallisting-container">
                    <?php if ( have_posts() ) : ?>

                        <?php while ( have_posts() ) : the_post(); ?>
                            <?php OpalListing_Template_Loader::get_template_part( 'content-single-place', array(), opallisting_single_the_place_layout() ); ?>
                        <?php endwhile; ?>

                       

                    <?php else : ?>
                        <?php get_template_part( 'content', 'none' ); ?>
                    <?php endif; ?>
                </div>
            </main><!-- .site-main -->
            <?php if ( opallisting_place_single_has_sidebar_right() ) : ?>
                <aside class="sidebar sidebar-right col-md-4 col-sm-4 col-xs-12" itemscope="itemscope" itemtype="http://schema.org/WPSideBar">
                    <?php dynamic_sidebar( 'opallisting-place-sidebar-right' ); ?>
                </aside>
            <?php endif; ?>
        </div>
    </div>
    <div>
    <?php
        // Get related place template
        opallisting_get_template( 'single-place/related-place' );
    ?>

    </div>

</section><!-- .content-area -->

<?php get_footer(); ?>
