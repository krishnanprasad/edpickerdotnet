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

get_header( apply_filters( 'rentme_fnc_get_header_layout', null ) ); ?>

	<div class="opallisting-single-header">

		<div id="section-slider" class="section">
			<!-- Gallery -->
			<?php opallisting_get_template( 'single-place/headers/slider.php' ); ?>
		</div>

		<div id="section-map" class="section hide">
			<!-- Map -->
			<?php opallisting_get_template( 'single-place/headers/map.php' ); ?>
		</div>

		<?php if ( get_post_meta( get_the_ID(), 'opallisting_ppt_enable_streetview', true ) ) : ?>
			<div id="section-street-view" class="section hide">
				<!-- Map Street Views -->
				<?php opallisting_get_template( 'single-place/headers/map-street-view.php' ); ?>
			</div>
		<?php endif; ?>

		<ul class="header-actions">
			<li>
				<a href="#" data-type="slider" class="active">
					<i class="fa fa-camera" aria-hidden="true"></i>
				</a>
			</li>
			<li>
				<a href="#" data-type="map">
					<i class="fa fa-map" aria-hidden="true"></i>
				</a>
			</li>
			<?php if ( get_post_meta( get_the_ID(), 'opallisting_ppt_enable_streetview', true ) ) : ?>
				<li>
					<a href="#" data-type="street-view">
						<i class="fa fa-street-view" aria-hidden="true"></i>
					</a>
				</li>
			<?php endif; ?>
		</ul>

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
	    </div>

	</section><!-- .content-area -->

<?php get_footer(); ?>