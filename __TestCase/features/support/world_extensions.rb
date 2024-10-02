module CajaBanco
  def page
    $page_manager.current_page
  end

  def page_manager
    $page_manager
  end
end

World(CajaBanco)