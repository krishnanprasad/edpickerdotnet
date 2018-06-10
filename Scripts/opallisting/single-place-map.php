<?php
/**
 * $Desc$
 *
 * @version    $Id$
 * @package    opallisting
 * @author     Opal  Team <info@wpopal.com >
 * @copyright  Copyright (C) 2016 wpopal.com. All Rights Reserved.
 * @license    GNU/GPL v2 or later http://www.gnu.org/licenses/gpl-2.0.html
 *
 * @website  http://www.wpopal.com
 * @support  http://www.wpopal.com/support/forum.html
 */

if ( ! defined( 'ABSPATH' ) ) {
	exit; // Exit if accessed directly
}

$main_class = opallisting_place_single_has_sidebar_left() && opallisting_place_single_has_sidebar_right() ? 'col-md-4 col-sm-4 col-xs-12' : ( opallisting_place_single_has_sidebar_left() || opallisting_place_single_has_sidebar_right() ? 'col-md-8 col-sm-8 col-xs-12' : 'col-md-12' );

get_header( apply_filters( 'rentme_fnc_get_header_layout', null ) );

?>

	<?php
		opallisting_get_template( 'parts/map-preview', array(
				'styles'	=> array(
						'width'		=> '100%',
						'height'	=> '600px'
					)
		) );
	?>

	<section id="main-container" class="site-main container" role="main">
		<div class="row">
			<?php if ( opallisting_place_single_has_sidebar_left() ) : ?>
				<aside class="sidebar sidebar-left col-md-4 col-xs-12" itemscope="itemscope" itemtype="http://schema.org/WPSideBar">
				   	<?php dynamic_sidebar( 'opallisting-place-sidebar-left' ); ?>
			  	</aside>
			<?php endif; ?>
			<main id="primary" class="content content-area <?php echo esc_attr( $main_class ) ?>">
				<div class="single-opallisting-container opallisting-container-map">
					<?php if ( have_posts() ) : ?>

						<?php while ( have_posts() ) : the_post(); ?>
							<div class="opallisting-place-meta">
								<header>
									<div class="title">
										<div class="pull-left">
											<?php
												$place = opallisting_get_place( get_the_ID() );
												$author = $place->getAuthor();
											?>
											<a href="<?php echo esc_url( OpalListing_User::get_tab_url( $author->ID, 'places' ) ) ?>">
								                <?php echo get_avatar( $author->ID, apply_filters( 'rentme_author_avatar_single_place', '100' ) ); ?>
								            </a>										
										</div>
										<div class="pull-left">
											<h1><?php the_title() ?></h1>
											<p><?php printf( '<i class="fa fa-map-marker" aria-hidden="true"></i> %s', esc_html( $place->get_address() )  ) ?></p>
										</div>
										<div class="pull-right review">
											<div class="review-wrapper">
						                        <?php opallisting_get_template( 'single-place/review-button' ); ?>
						                    </div>
										</div>
									</div>
									<div class="meta">
										<div class="pull-left">
											<div class="rating">
						                    	<?php opallisting_get_template( 'single-place/rating' ); ?>
											</div>
						                </div>
						                <div class="pull-right">
						                    <div class="claim-wrapper pull-left">
						                        <?php opallisting_get_template( 'single-place/claim' ); ?>
						                    </div>
						                    <div class="share-wrapper pull-left">
						                        <?php opallisting_get_template( 'single-place/share' ); ?>
						                    </div>
							                <div class="favorite-button pull-left">
							                    <?php opallisting_get_template( 'single-place/favorite-button' ); ?>
							                </div>
						                </div>
									</div>
								</header>
							</div>
		                    <?php OpalListing_Template_Loader::get_template_part( 'content-single-place', array(), opallisting_single_the_place_layout() ); ?>
						<?php endwhile; ?>

						<?php
							// Get related place template
							opallisting_get_template( 'single-place/related-place' );
						?>

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
	</section><!-- .content-area -->

<?php get_footer(); ?>