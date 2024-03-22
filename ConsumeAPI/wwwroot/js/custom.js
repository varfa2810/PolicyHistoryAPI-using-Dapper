//$('.btnNext').click(function () {
//    const nextTabLinkEl = $('.nav-tabs .active').closest('li').next('li').find('a')[0];
//    const nextTab = new bootstrap.Tab(nextTabLinkEl);
//    nextTab.show();
//  });
  $('.btnPrevious').click(function () {
    const prevTabLinkEl = $('.nav-tabs .active').closest('li').prev('li').find('a')[0];
    const prevTab = new bootstrap.Tab(prevTabLinkEl);
    prevTab.show();
  });