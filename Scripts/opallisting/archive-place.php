<?php
if ( ! defined( 'ABSPATH' ) ) {
	exit;
}

$main_class = opallisting_place_archive_has_sidebar_left() && opallisting_place_archive_has_sidebar_right() ? 'col-md-6 col-xs-12' : ( opallisting_place_archive_has_sidebar_left() || opallisting_place_archive_has_sidebar_right() ? 'col-md-9 col-xs-12' : 'col-md-12' );

get_header( apply_filters( 'rentme_fnc_get_header_layout', null ) );
?>
<?php do_action( 'rentme_template_main_before' ); ?>

    <section id="main-container" class="site-main container" role="main">
        <div class="row">
            <?php if ( opallisting_place_archive_has_sidebar_left() ) : ?>
                <aside class="sidebar sidebar-left col-md-3 col-xs-12" itemscope="itemscope" itemtype="http://schema.org/WPSideBar">
                    <?php dynamic_sidebar( 'opallisting-place-sidebar-left' ); ?>
                </aside>
            <?php endif; ?>

            <main id="primary" class="content content-area <?php echo esc_attr( $main_class ) ?>">
                <?php if ( have_posts() ) : ?>

                    <div class="opallisting-archive-container">
                        <div class="opallisting-archive-top">
                            <?php opallisting_get_template( 'globals/before-loop.php' ); ?>
                        </div>

                        <div class="opallisting-archive-bottom opallisting-rows">
                            <div class="<?php echo apply_filters('opallisting_row_container_class', 'opal-row');?>">
                                <?php if ( opallisting_get_display_mode() == 'list' ):?>
                                    <div class="row">
                                        <?php while ( have_posts() ) : the_post(); ?>
                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                <?php opallisting_get_template( 'content-place-list' ); ?>
                                            </div>
                                        <?php endwhile; wp_reset_postdata(); ?>
                                    </div>
                                <?php else : ?>
                                    <?php
                                        $column = opallisting_get_archive_grid_columns();
                                        $clscol = floor( 12 / $column );
                                        $cnt = 0;
                                        while ( have_posts() ) : the_post();
                                        $cls = '';
                                        if( $cnt++ % $column == 0 ){
                                            $cls .= ' first-child';
                                        }
                                    ?>
                                        <?php if ( $cnt % $column === 1 ) : ?>
                                            <div class="row">
                                        <?php endif; ?>
                                                <div class="<?php echo esc_attr( $cls ); ?> col-lg-<?php echo esc_attr( $clscol ) ?> col-md-<?php echo esc_attr( $clscol ) ?> col-sm-<?php echo esc_attr( $clscol ) ?> col-xs-12">
                                                    <?php opallisting_get_template( 'content-place-grid' ); ?>
                                                </div>
                                        <?php if ( $cnt % $column === 0 || $wp_query->found_posts == $cnt || $wp_query->post_count === $cnt ) : ?>
                                            </div>
                                        <?php endif; ?>
                                    <?php endwhile; wp_reset_postdata(); ?>
                                <?php endif; ?>
                            </div>
                        </div>

                    </div>
                    <div class="w-pagination">
                        <?php opallisting_pagination( $wp_query ); ?>
                    </div>

                <?php else : ?>
                    <?php get_template_part( 'content', 'none' ); ?>
                <?php endif; ?>

            </main><!-- .site-main -->
            <?php if ( opallisting_place_archive_has_sidebar_right() ) : ?>
                <aside class="sidebar sidebar-right col-md-3 col-xs-12" itemscope="itemscope" itemtype="http://schema.org/WPSideBar">
                    <?php dynamic_sidebar( 'opallisting-place-sidebar-right' ); ?>
                </aside>
            <?php endif; ?>
        </div>
    </section><!-- .content-area -->

<?php get_footer(); ?>
